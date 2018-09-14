using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TinyRails_Composer
{
	public enum ESaveOption
	{
		Auto,
		Manual,
		OnClose,
	}

	internal static class Configuration
	{
		public static ObservableCollection<ResourceData> ResourceList = new ObservableCollection<ResourceData>();
		public static ObservableCollection<UnlockedData> UnlockedList = new ObservableCollection<UnlockedData>();
		public static ObservableCollection<NotCollectedData> NotCollectedList = new ObservableCollection<NotCollectedData>();
		public static ESaveOption SaveOption;
	}
}
