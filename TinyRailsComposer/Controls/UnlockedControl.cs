using System.Windows.Forms;

namespace TinyRails_Composer.Controls
{
	public partial class UnlockedControl: UserControl
	{
		private readonly BindingSource bs;

		public UnlockedControl()
		{
			InitializeComponent();

			bs = new BindingSource
			{
				DataSource = new UnlockedData()
			};

			ChkRegion.DataBindings.Add("Checked", bs, "Unlocked", true, DataSourceUpdateMode.OnPropertyChanged);
			ChkRegion.DataBindings.Add("Text", bs, "Region", true, DataSourceUpdateMode.OnPropertyChanged);
		}

		public UnlockedData DataSource
		{
			get { return bs.DataSource as UnlockedData; }
			set { bs.DataSource = value; ChkRegion.Checked = value.Unlocked; ChkRegion.Text = value.Region; }
		}
	}
}
