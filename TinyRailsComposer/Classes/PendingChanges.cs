namespace TinyRails
{
	// found in www (https://stackoverflow.com/questions/7995893/why-doesnt-anyone-use-the-inotifypropertychanging#7996089)
	public delegate void AcceptPendingChangeHandler(object sender, AcceptPendingChangeEventArgs e);

	public interface IAcceptPendingChange
	{
		event AcceptPendingChangeHandler PendingChange;
	}

	public class AcceptPendingChangeEventArgs : System.EventArgs
	{
		public string PropertyName { get; private set; }
		public object CurrentValue { get; private set; }
		public object NewValue { get; private set; }
		public bool CancelPendingChange { get; set; }

		public AcceptPendingChangeEventArgs(string propertyName, object currentValue, object newValue)
		{
			PropertyName = propertyName;
			CurrentValue = currentValue;
			NewValue = newValue;
		}
	}

//	class ViewModelBase : IAcceptPendingChange
//	{
//		protected virtual bool RaiseAcceptPendingChange(
//			string propertyName,
//			object newValue)
//		{
//			var e = new AcceptPendingChangeEventArgs(propertyName, newValue);
//				var handler = this.PendingChange;
//			if (null != handler)
//			{
//				handler(this, e);
//			}
//
//			return !e.CancelPendingChange;
//		}
//	}

//	class SomeViewModel : ViewModelBase
//	{
//		public string Foo
//		{
//			get { return this.foo; }
//			set
//			{
//				if (this.RaiseAcceptPendingChange("Foo", value))
//				{
//					this.RaiseNotifyPropertyChanging("Foo");
//					this.foo = value;
//					this.RaiseNotifyPropretyChanged("Foo");
//				}
//			}
//		}
//	}
}
