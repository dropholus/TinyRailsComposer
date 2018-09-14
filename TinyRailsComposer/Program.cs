using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;

namespace TinyRails_Composer
{
	internal static class Program
	{
		private static MainForm MainWindow;
		private static Reader.CsvHandler Csv = new Reader.CsvHandler();
		private static readonly string CurrDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		private static readonly string FilePathResource = System.IO.Path.Combine(CurrDir, @"resource.csv");
		private static readonly string FilePathCollected = System.IO.Path.Combine(CurrDir, @"collected.csv");
		private static readonly string FilePathUnlocked = System.IO.Path.Combine(CurrDir, @"unlocked.csv");
		private static readonly string FilePathOptions = System.IO.Path.Combine(CurrDir, @"TinyRails.opt");

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			LoadOption();

			Configuration.ResourceList.CollectionChanged += ResourceListAll_CollectionChanged;
			Configuration.UnlockedList.CollectionChanged += UnlockedDictionary_CollectionChanged;

			/* Read the resources list from an csv file.
			 * This was created by pasting the content (of the resource tables)
			 * of 'http://tinyrails.wikia.com/wiki/Resources'
			 * to an table calculation program and exported it as an csv file. */

			/* this list contains all resources and their location */
			Csv.ReadResourceFile(FilePathResource);

			/* This list contains the cities and their resources given. */
			Csv.ReadCollectedFile(FilePathCollected);

			/* This list contains the unlocked regions. */
			Csv.ReadUnlockFile(FilePathUnlocked);

			/* Now build the Unlocked Region List and react on changing items */
			foreach ( var item in Configuration.ResourceList )
			{
				bool found = false;

				foreach ( var inner in Configuration.UnlockedList )
				{
					if ( item.Region == inner.Region )
					{
						found = true;
					}
				}

				if ( !found )
				{
					Configuration.UnlockedList.Add(new UnlockedData() { Region = item.Region, Unlocked = item.Unlocked });
				}

				/* fill the not collected list */
				bool colfound = false;
				foreach ( var inner in Configuration.NotCollectedList )
				{
					if ( inner.Resource == item.Resource )
					{
						colfound = true;
						inner.Amount += item.Amount - item.Collected;
					}
				}
				if ( !colfound)
				{
					NotCollectedData ncd = new NotCollectedData() { Resource = item.Resource, Amount = item.Amount - item.Collected };
					Configuration.NotCollectedList.Add(ncd);
				}
			}

			/* now react on changes of the unlocked data */
			foreach ( UnlockedData ud in Configuration.UnlockedList )
			{
				ud.PropertyChanged += Unlocked_PropertyChanged;

				/* and set the unlocked features of the resources list */
				foreach ( var item in Configuration.ResourceList )
				{
					if ( item.Region == ud.Region )
					{
						item.Unlocked = ud.Unlocked;
					}
				}
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			MainWindow = new MainForm();
			MainWindow.OnSave += Save;
			Application.Run(MainWindow);

			SaveOption();

			switch ( Configuration.SaveOption )
			{
			case ESaveOption.Auto:
				break;
			case ESaveOption.Manual:
			case ESaveOption.OnClose:
				Save();
				break;
			default:
				break;
			}
		}

		private static void Save(object sender = null, EventArgs e = null)
		{
			Csv.WriteUnlockFile(FilePathUnlocked);
			Csv.WriteCollectedFile(FilePathCollected);
		}

		private static void SaveOption()
		{
			try
			{
				System.IO.TextWriter tw = new System.IO.StreamWriter(FilePathOptions);

				tw.WriteLine("SaveOption=" + Configuration.SaveOption);
				
				tw.Flush();
				tw.Close();
			}
			catch
			{
			}
		}
		private static void LoadOption()
		{
			if ( System.IO.File.Exists(FilePathOptions) )
			{
				System.IO.TextReader tr = System.IO.File.OpenText(FilePathOptions);
				string line = string.Empty;

				while ( null != (line = tr.ReadLine()) )
				{
					string[] opt = line.Split('=');

					if ( (opt != null) && (opt.Length == 2) )
					{
						switch ( opt[0] )
						{
						case "SaveOption":
							try { Configuration.SaveOption = (ESaveOption)Enum.Parse(typeof(ESaveOption), opt[1], true); }
							catch { }
							break;
						default:
							break;
						}
					}
				}

				tr.Close();
				tr.Dispose();
			}
		}

		private static void UnlockedDictionary_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			switch ( e.Action )
			{
			case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
				{
					foreach ( var item in e.NewItems )
					{
						UnlockedData ud = item as UnlockedData;

						ud.PropertyChanged += Unlocked_PropertyChanged;

						SetRegionLock(ud.Region, ud.Unlocked);
					}
				}
				break;
			default:
			case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
			case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
			case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
			case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
				break;
			};
		}

		private static void Unlocked_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			UnlockedData ud = sender as UnlockedData;

			foreach ( var item in Configuration.UnlockedList )
			{
				if ( item.Region == ud.Region )
				{
					 SetRegionLock(ud.Region, ud.Unlocked);
				}
			}

			foreach(var item in Configuration.ResourceList)
			{
				if ( item.Region == ud.Region )
				{
					SetRegionLock(ud.Region, ud.Unlocked);
				}
			}

			MainWindow.RefreshFilter();
		}

		private static void SetRegionLock(string region, bool unlocked)
		{
			foreach ( var item in Configuration.ResourceList )
			{
				if ( item.Region == region )
				{
					item.Unlocked = unlocked;
				}
			}
			switch ( Configuration.SaveOption )
			{
			case ESaveOption.Auto:
				Csv.WriteUnlockFile(FilePathUnlocked);
				break;
			case ESaveOption.Manual:
			case ESaveOption.OnClose:
			default:
				break;
			}
			
		}

		private static void ResourceListAll_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			switch ( e.Action )
			{
			case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
				{
					foreach ( var item in e.NewItems )
					{
						ResourceData ud = item as ResourceData;

						ud.PropertyChanged += Resource_PropertyChanged;
						ud.PendingChange += Ud_PendingChange;
					}
				}
				break;
			default:
			case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
			case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
			case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
			case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
				break;
			};
		}

		private static void Ud_PendingChange(object sender, TinyRails.AcceptPendingChangeEventArgs e)
		{
			foreach ( var item in Configuration.NotCollectedList )
			{
				if ( item.Resource == e.PropertyName )
				{
					if ( ((e.NewValue).GetType() == typeof(int)) && (((e.CurrentValue).GetType() == typeof(int))) )
					{
						item.Amount -= ((int)e.NewValue - (int)e.CurrentValue);
					}


					break;
				}
			}
		}

		private static void Resource_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			switch ( e.PropertyName )
			{
			default:
				break;
			case "Collected":
				switch ( Configuration.SaveOption )
				{
				case ESaveOption.Auto:
					Csv.WriteCollectedFile(FilePathCollected);
					break;
				case ESaveOption.Manual:
				case ESaveOption.OnClose:
				default:
					break;
				}
				break;
			}
		}
	}
}
