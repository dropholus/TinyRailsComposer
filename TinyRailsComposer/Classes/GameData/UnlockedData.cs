namespace TinyRails_Composer
{
	[System.Diagnostics.DebuggerDisplay("{DebuggerDisplay,nq}")]
	public class UnlockedData: System.ComponentModel.INotifyPropertyChanged, System.Windows.Forms.IBindableComponent, System.IDisposable, System.IComparable
	{
		#region DebuggerDisplay

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string DebuggerDisplay
		{
			get
			{
				return string.Format("Location={0}, Unlocked={1}", Region, Unlocked);
			}
		}

		#endregion DebuggerDisplay

		///<summary>zum Einhängen von mehreren Objekten (vereinfachte Form der DependencyProperties)</summary>
		public System.Collections.Generic.Dictionary<string, object> TagDict = new System.Collections.Generic.Dictionary<string, object>();

		#region Properties

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _Region;

		public string Region
		{
			get { return _Region; }
			internal set { CheckSetAndSend(ref _Region, value); }
		}

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private bool _Unlocked;

		public bool Unlocked
		{
			get { return _Unlocked; }
			set { CheckSetAndSend(ref _Unlocked, value); }
		}

		#endregion Properties

		public int CompareTo(object obj) 
		{
			UnlockedData data = obj as UnlockedData;
			if (data == null) 
			{
				throw new System.ArgumentException("Object is not UnlockedData");
			}

			return this.Region.CompareTo(data.Region);
		}

		#region INotifyPropertyChanged Members

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler handler = PropertyChanged;

			if ( handler != null )
			{
				if ( System.Windows.Forms.Application.OpenForms.Count > 0 )
				{
					System.Windows.Forms.Form mainForm = System.Windows.Forms.Application.OpenForms[0];

					if ( mainForm != null )
					{
						if ( mainForm.InvokeRequired )
						{
							// We are not in UI Thread now
							mainForm.Invoke(handler, new object[] { this, new System.ComponentModel.PropertyChangedEventArgs(propertyName) });
						}
						else
						{
							handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
						}
					}
				}
			}
		}

		protected bool CheckSetAndSend<T>(ref T field, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
		{
			if ( System.Collections.Generic.EqualityComparer<T>.Default.Equals(field, value) )
			{
				return false;
			}

			field = value;

			OnPropertyChanged(propertyName);

			return true;
		}

		#endregion INotifyPropertyChanged Members

		#region IBindableComponent Members

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private System.Windows.Forms.BindingContext bindingContext;

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private System.Windows.Forms.ControlBindingsCollection dataBindings;

		[System.ComponentModel.Browsable(false)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		public System.Windows.Forms.BindingContext BindingContext
		{
			get
			{
				if ( bindingContext == null )
				{
					bindingContext = new System.Windows.Forms.BindingContext();
				}
				return bindingContext;
			}
			set
			{
				bindingContext = value;
			}
		}

		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		public System.Windows.Forms.ControlBindingsCollection DataBindings
		{
			get
			{
				if ( dataBindings == null )
				{
					dataBindings = new System.Windows.Forms.ControlBindingsCollection(this);
				}
				return dataBindings;
			}
		}

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		public System.ComponentModel.ISite Site
		{
			get { return null; }
			set { }
		}

		#endregion IBindableComponent Members

		#region Dispose

		public event System.EventHandler Disposed;

		public void Dispose()
		{
			Dispose(true);
		}

		protected virtual void Dispose(bool components)
		{
			if ( components )
			{
			}

			//Disposed?.Invoke(this, System.EventArgs.Empty);
		}

		#endregion Dispose
	}
}
