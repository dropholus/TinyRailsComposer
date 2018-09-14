using MyControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace TinyRails_Composer
{
	public partial class MainForm: Form
	{
		private int SelectedColumnIndex = 0;
		private BindingSource bs = new BindingSource();
		private BindingSource ncbinding = new BindingSource();

		private static BindingList<ResourceData> ResourceListBinding = new BindingList<ResourceData>();
		private DataFilter Filter = new DataFilter("");
		private string SelectedRegion = "All";

		public EventHandler OnSave;

		private string FilterString  =string.Empty;

		public MainForm()
		{
			InitializeComponent();
		}

		private void NewShowEntry(string name)
		{
			System.Windows.Forms.RadioButton rb = new RadioButton();

			rb.CheckedChanged += ShowOnly_CheckedChanged;
			rb.Name = name;
			rb.Text = name;

			FlpShowOnly.Controls.Add(rb);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			DataGridView.ColumnHeaderMouseClick += DataGridView_ColumnHeaderMouseClick;
			DataGridView.KeyPress += DataGridView_KeyPress;

			switch ( Configuration.SaveOption )
			{
			case ESaveOption.Auto:
				RadAuto.Checked = true;
				BtnSave.Visible = false;
				break;
			case ESaveOption.Manual:
				RadManual.Checked = true;
				BtnSave.Visible = true;
				break;
			case ESaveOption.OnClose:
				RadClose.Checked = true;
				BtnSave.Visible = false;
				break;
			default:
				break;
			}

			Configuration.UnlockedList = new ObservableCollection<UnlockedData>(Configuration.UnlockedList.OrderBy(Region => Region));
			NewShowEntry("All");

			foreach ( var item in Configuration.UnlockedList )
			{
				TinyRails_Composer.Controls.UnlockedControl lc = new TinyRails_Composer.Controls.UnlockedControl
				{
					DataSource = item
				};

				try
				{
					FlpUnlockedRegions.Controls.Add(lc);
				}
				catch ( Exception exc )
				{
					/* to prevent compiler warnings */
					exc.Source = "Composer";
				}

				NewShowEntry(item.Region);
			}

			foreach ( var item in Configuration.ResourceList )
			{
				ResourceListBinding.Add(item);
			}

			RefreshFilter();

			bs.DataSource = ResourceListBinding;

			DataGridView.Columns.Add("1", "1"); // because of Linux
			DoBinding(bs);
			DataGridView.Columns.Remove("1"); // because of Linux

			ncbinding.DataSource = Configuration.NotCollectedList;
			NotCollectedView.DataSource = ncbinding;

			try
			{
				NotCollectedView.Columns.Remove("Data Bindings");
			}
			catch { }
			try
			{
				NotCollectedView.Columns.Remove("DataBindings");
			}
			catch { }
			try
			{
				NotCollectedView.Columns.Remove("Site");
			}
			catch { }
		}

		void DataGridView_KeyPress (object sender, KeyPressEventArgs e)
		{
			if ( (e.KeyChar == 102 /*f*/) || ( e.KeyChar == 70 /*F*/) )
			{
				ResourceListBinding[SelectedColumnIndex].Collected = ResourceListBinding[SelectedColumnIndex].Amount;
			}

			if ( (e.KeyChar == 117 /*u*/) || ( e.KeyChar == 85 /*U*/) )
			{
				ResourceListBinding[SelectedColumnIndex].Collected = 0;
			}
		}

		private void DataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			DataGridView dgv = sender as DataGridView;

			//DoBinding(null);

			switch ( dgv.Columns[e.ColumnIndex].Name )
			{
			case "City":
				Configuration.ResourceList = new ObservableCollection<ResourceData>(Configuration.ResourceList.OrderBy( x => x.City ));
				break;
			case "Region":
				Configuration.ResourceList = new ObservableCollection<ResourceData>(Configuration.ResourceList.OrderBy( x => x.Region ));
				break;
			case "Amount":
				Configuration.ResourceList = new ObservableCollection<ResourceData>(Configuration.ResourceList.OrderBy( x => x.Amount ));
				break;
			case "Resource":
				Configuration.ResourceList = new ObservableCollection<ResourceData>(Configuration.ResourceList.OrderBy( x => x.Resource ));
				break;
			case "Collected":
				Configuration.ResourceList = new ObservableCollection<ResourceData>(Configuration.ResourceList.OrderBy( x => x.Collected ));
				break;
			case "Fulfilled":
				Configuration.ResourceList = new ObservableCollection<ResourceData>(Configuration.ResourceList.OrderBy( x => x.Fulfilled ));
				break;
			};

			//DoBinding(bs);

			RefreshFilter();
		}

		private void DoBinding(object datasource)
		{
			DataGridView.DataSource = datasource;

			if ( datasource != null )
			{
				try
				{
					DataGridView.Columns.Remove("Data Bindings");
				}
				catch { }
				try
				{
					DataGridView.Columns.Remove("DataBindings");
				}
				catch { }
				try
				{
					DataGridView.Columns.Remove("Site");
				}
				catch { }
				try
				{
					DataGridView.Columns.Remove("Unlocked");
				}
				catch { }
				try
				{
					DataGridView.Columns.Remove("Fulfilled");
				}
				catch { }

				foreach ( DataGridViewColumn item in DataGridView.Columns )
				{
					if ( item.HeaderText == "Amount" || item.HeaderText == "Collected" )
					{
						item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					}
				}
			}
		}

		private void NumberControl1_OnOk(object sender, NumberControl.NumberEventArgs e)
		{
			if ( SelectedColumnIndex >= 0 && SelectedColumnIndex < Configuration.ResourceList.Count )
			{
				switch ( e.Direction )
				{
				case NumberControl.NumberEventArgs.Dir.Positive:
				case NumberControl.NumberEventArgs.Dir.Negative:
					ResourceListBinding[SelectedColumnIndex].Collected += e.Number;
					break;
				case NumberControl.NumberEventArgs.Dir.Set:
					ResourceListBinding[SelectedColumnIndex].Collected = e.Number;
					break;
				}
			}
		}

		private void TxtFilter_TextChanged(object sender, EventArgs e)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			TextBox tb = sender as TextBox;

			if ( null == tb )
			{
			}
			else
			{
				string text = tb.Text;

				sb.Append("City=*");
				sb.Append(text);
				sb.Append("*");
				sb.Append(" OR ");

				sb.Append("Region=*");
				sb.Append(text);
				sb.Append("*");
				sb.Append(" OR ");

				sb.Append("Resource=*");
				sb.Append(text);
				sb.Append("*");

				//sb.Append(" OR ");
			}

			FilterString = sb.ToString();

			RefreshFilter();
		}

		public void RefreshFilter(object sender = null, EventArgs e = null)
		{
			if ( DataFilter.ValidateFilterString(FilterString) )
			{
				Filter = new DataFilter(FilterString);
				FilterInit();
			}
		}

		//private List<ResourceData> TL = new List<ResourceData>();

		private void FilterInit()
		{
			lock ( Configuration.ResourceList )
			{
				ResourceListBinding.Clear();

				var ienum = Configuration.ResourceList.Where(pd => Filter.Validate(pd));

				DoBinding(null);

				if ( ienum.Count() > 0 )
				{
					foreach ( var item in ienum )
					{
						if ( item.Unlocked == true && ((item.Region == SelectedRegion) || (SelectedRegion == "All")) )
						{
							if ( item.Fulfilled )
							{
								if ( ChkShowFulfilled.Checked )
								{
									ResourceListBinding.Add(item);
								}
							}
							else
							{
								ResourceListBinding.Add(item);
							}
						}
					}
				}
				DoBinding(bs);
			}
		}

		private void DataGridView_SelectionChanged(object sender, EventArgs e)
		{
			DataGridView dgv = sender as DataGridView;

			DataGridViewSelectedCellCollection dgvscc = dgv.SelectedCells;

			foreach ( DataGridViewTextBoxCell item in dgvscc )
			{
				SelectedColumnIndex = item.RowIndex;
			}
		}

		private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			DataGridView dc = (DataGridView)sender;

			ResourceData rd = ResourceListBinding[e.RowIndex];

			for ( int i = 0; i < dc.Columns.Count; i++ )
			{
				if ( dc.Rows[e.RowIndex].Cells[i].Visible )
				{
					DataGridViewCellStyle cellstyle = dc.Rows[e.RowIndex].Cells[i].Style;
					
					if ( rd.Fulfilled )
					{
						cellstyle.BackColor = System.Drawing.Color.LawnGreen;
						cellstyle.ForeColor = System.Drawing.Color.Black;
					}
					else if ( rd.Collected == 0 )
					{
						cellstyle.BackColor = System.Drawing.Color.WhiteSmoke;
						cellstyle.ForeColor = System.Drawing.Color.Black;
					}
					else
					{
						float f = ((float)rd.Collected) / ((float)rd.Amount);

						if ( f < 0.2 )
						{
							cellstyle.BackColor = System.Drawing.Color.MistyRose;
							cellstyle.ForeColor = System.Drawing.Color.Black;
						}
						else if ( f < 0.5 )
						{
							cellstyle.BackColor = System.Drawing.Color.Khaki;
							cellstyle.ForeColor = System.Drawing.Color.Black;
						}
						else if ( f < 0.7 )
						{
							cellstyle.BackColor = System.Drawing.Color.PaleGreen;
							cellstyle.ForeColor = System.Drawing.Color.Black;
						}
						else if ( f < 1 )
						{
							cellstyle.BackColor = System.Drawing.Color.LightGreen;
							cellstyle.ForeColor = System.Drawing.Color.Black;
						}
					}
				}
			}
		}

		private void NotCollectedView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			DataGridView dc = (DataGridView)sender;

			NotCollectedData ncd = Configuration.NotCollectedList[e.RowIndex];

			for ( int i = 0; i < dc.Columns.Count; i++ )
			{
				if ( dc.Rows[e.RowIndex].Cells[i].Visible )
				{
					DataGridViewCellStyle cellstyle = dc.Rows[e.RowIndex].Cells[i].Style;

					int amount = ncd.Amount;

					if ( amount == 0 )
					{
						cellstyle.BackColor = System.Drawing.Color.LimeGreen;
						cellstyle.ForeColor = System.Drawing.Color.Black;
					}
					else
					{
						cellstyle.BackColor = System.Drawing.Color.WhiteSmoke;
						cellstyle.ForeColor = System.Drawing.Color.Black;
					}
				}
			}
		}

		private void Save_Click(object sender, EventArgs e)
		{
			EventHandler Handler = OnSave;

			if ( null != Handler)
			{
				Handler(this, null);
			}
		}

		private void ShowOnly_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton rb = sender as RadioButton;

			if ( null != rb )
			{
				SelectedRegion = rb.Name;

				RefreshFilter();
			}
		}

		private void RadManual_CheckedChanged(object sender, EventArgs e)
		{
			Configuration.SaveOption = ESaveOption.Manual;
			BtnSave.Visible = true;
		}

		private void RadClose_CheckedChanged(object sender, EventArgs e)
		{
			Configuration.SaveOption = ESaveOption.OnClose;
			BtnSave.Visible = false;
		}

		private void RadAuto_CheckedChanged(object sender, EventArgs e)
		{
			Configuration.SaveOption = ESaveOption.Auto;
			BtnSave.Visible = false;
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{

		}
	}
}
