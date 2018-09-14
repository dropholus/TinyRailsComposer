using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TinyRails_Composer.Reader
{
	public class CsvHandler
	{
		internal void ReadResourceFile(string filePath)
		{
			try
			{
				if ( System.IO.File.Exists(filePath) )
				{
					System.IO.TextReader tr = System.IO.File.OpenText(filePath);
					string key = string.Empty;
					int amount = 0;
					string city = string.Empty;
					string region = string.Empty;
					string line = string.Empty;

					while ( null != (line = tr.ReadLine()) )
					{
						string[] la = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);

						/*
							Acai
							Amount Needed 	City 				Region
							25				Lodwar, KE 			Africa East
							50				Moundou, TD 		Africa East
							150				Antofagasta, CL 	S. America Lower
							1				Bogota, CO 			S. America Upper
							1,225		Total Amount
						*/
						if ( la.Length == 1 ) // Resource
						{
							key = la[0].Trim();
							city = string.Empty;
							region = string.Empty;
							amount = 0;
						}
						else if ( la.Length == 2 ) // summarize
						{
							key = string.Empty;
							city = string.Empty;
							region = string.Empty;
							amount = 0;
						}
						else if ( la.Length == 3 ) // Resource info
						{
							if ( la[0].Contains("Amount") )
							{
							}
							else
							{
								amount = int.Parse(la[0].Trim());
								city = la[1].Trim();
								region = la[2].Trim();

								if ( amount == 1 )
								{ amount = 1000; }
							}
						}
						else // maybe empty line
						{
							key = string.Empty;
							city = string.Empty;
							region = string.Empty;
							amount = 0;
						}

						if ( key != string.Empty && amount != 0 )
						{
							ResourceData ld = new ResourceData
							{
								City = city,
								Amount = amount,
								Region = region,
								Resource = key
							};

							//ObservableCollection<ResourceData> list = null;

							//if ( Configuration.ResourceDictionary.TryGetValue(key, out list) )
							//{
							//}
							//else
							//{
							//	list = new ObservableCollection<ResourceData>();
							//	Configuration.ResourceDictionary.Add(key, list);
							//}

							//list.Add(ld);

							Configuration.ResourceList.Add(ld);
						}
					}

					tr.Close();
					tr.Dispose();
				}
			}
			catch ( Exception exc )
			{
				exc.Source = "Composer"; // to remove compiler warnings
			}
		}

		internal void ReadCollectedFile(string filePath)
		{
			try
			{
				if ( System.IO.File.Exists(filePath) )
				{
					System.IO.TextReader tr = System.IO.File.OpenText(filePath);

					int collected = 0;
					string city = string.Empty;
					string line = string.Empty;

					while ( null != (line = tr.ReadLine()) )
					{
						string[] la = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);

						/* 25	Lodwar, KE */
						if ( la.Length == 2 )
						{
							collected = int.Parse(la[0].Trim());
							city = la[1].Trim();

							foreach ( var item in Configuration.ResourceList )
							{
								if ( item.City == city )
								{
									item.Collected = collected;
								}
							}
						}
					}

					tr.Close();
					tr.Dispose();
				}
			}
			catch ( Exception exc )
			{
				exc.Source = "Composer"; // to remove compiler warnings
			}
		}

		internal void WriteCollectedFile(string filePath)
		{
			/* 25	<tab>	Lodwar, KE */
			try
			{
				System.IO.TextWriter tw = new System.IO.StreamWriter(filePath);
				int testcounter = 0;

				foreach ( var item in Configuration.ResourceList )
				{
					testcounter++;
					if ( item.Collected > 0 )
					{
						tw.WriteLine(item.Collected.ToString() + "\t" + item.City);
					}
				}

				tw.Flush();
				tw.Close();
			}
			catch
			{
			}
		}

		internal void ReadUnlockFile(string filePath)
		{
			try
			{
				if ( System.IO.File.Exists(filePath) )
				{
					System.IO.TextReader tr = System.IO.File.OpenText(filePath);

					bool unlocked = false;
					string region = string.Empty;
					string line = string.Empty;

					while ( null != (line = tr.ReadLine()) )
					{
						string[] la = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);

						/* True		<tab>	Oceania East */
						if ( la.Length == 2 )
						{
							unlocked = bool.Parse(la[0].Trim());
							region = la[1].Trim();

							bool found = false;

							foreach ( var inner in Configuration.UnlockedList )
							{
								if ( region == inner.Region )
								{
									found = true;
								}
							}

							if ( !found )
							{
								Configuration.UnlockedList.Add(new UnlockedData() { Region = region, Unlocked = unlocked });
							}
						}
					}

					tr.Close();
					tr.Dispose();
				}
			}
			catch ( Exception exc )
			{
				Exception c = exc; // to remove compiler warnings
				c.Source = "Composer";
			}
		}

		internal void WriteUnlockFile(string filePath)
		{
			try
			{
				System.IO.TextWriter tw = new System.IO.StreamWriter(filePath);

				/* True		<tab>	Africa East */
				foreach ( var item in Configuration.UnlockedList )
				{
					if ( item.Unlocked )
					{
						tw.WriteLine(item.Unlocked.ToString() + "\t" + item.Region);
					}
				}

				tw.Flush();
				tw.Close();
			}
			catch
			{
			}
		}
	}
}
