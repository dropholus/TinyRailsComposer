namespace TinyRails_Composer
{
	[System.Diagnostics.DebuggerDisplay("{DebuggerDisplay,nq}")]
	public class ResourceData: System.ComponentModel.INotifyPropertyChanged, System.ComponentModel.INotifyPropertyChanging, System.Windows.Forms.IBindableComponent, System.IDisposable, TinyRails.IAcceptPendingChange
	{
		#region DebuggerDisplay

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string DebuggerDisplay
		{
			get
			{
				if ( Fulfilled )
				{
					return string.Format("Amount={2,4} ☺, Location={0}/{1}, Resource={3}", City, Region, Amount, Resource);
				}
				else
				{
					return string.Format("Amount={3,4}/{2,4}, Location={0}/{1}, Resource={4}", City, Region, Amount, Collected, Resource);
				}
			}
		}

		#endregion DebuggerDisplay

		///<summary>zum Einhängen von mehreren Objekten (vereinfachte Form der DependencyProperties)</summary>
		public System.Collections.Generic.Dictionary<string, object> TagDict = new System.Collections.Generic.Dictionary<string, object>();

		#region Csv Properties

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _City;

		public string City
		{
			get { return _City; }
			internal set { CheckSetAndSend(ref _City, value); }
		}

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _Region;

		public string Region
		{
			get { return _Region; }
			internal set { CheckSetAndSend(ref _Region, value); }
		}

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private int _Amount;

		public int Amount
		{
			get { return _Amount; }
			internal set { CheckSetAndSend(ref _Amount, value); }
		}

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _Resource;

		public string Resource
		{
			get { return _Resource; }
			internal set { CheckSetAndSend(ref _Resource, value); }
		}

		#endregion Csv Properties

		#region own Properties

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private int _Collected;

		public int Collected
		{
			get { return _Collected; }
			set
			{
				CheckSetAndSend(ref _Collected, value);

				if ( _Collected >= Amount )
				{
					_Collected = Amount;
					_Fulfilled = true;
				}
			}
		}

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private bool _Fulfilled;

		public bool Fulfilled
		{
			get { return _Fulfilled; }
			set { CheckSetAndSend(ref _Fulfilled, value); if ( _Fulfilled ) { Collected = Amount; } }
		}

		#endregion own Properties

		#region unlocked

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private bool _Unlocked;

		public bool Unlocked
		{
			get { return _Unlocked; }
			set { CheckSetAndSend(ref _Unlocked, value); }
		}

		#endregion unlocked

		#region INotifyProperty* Members

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

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

		protected virtual void OnPropertyChanging(string propertyName)
		{
			System.ComponentModel.PropertyChangingEventHandler handler = PropertyChanging;

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
							handler(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
						}
					}
				}
			}
		}

		#endregion INotifyProperty* Members

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

		#region PendingChanges

		public event TinyRails.AcceptPendingChangeHandler PendingChange;

		protected virtual bool OnPendingChange(string propertyName, object currentval, object newval)
		{
			TinyRails.AcceptPendingChangeHandler handler = PendingChange;

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
							TinyRails.AcceptPendingChangeEventArgs ea = new TinyRails.AcceptPendingChangeEventArgs(propertyName, currentval, newval);
							handler(this, ea);

							return !ea.CancelPendingChange;
						}
					}
				}
			}

			return true;
		}

		#endregion PendingChanges

		protected bool CheckSetAndSend<T>(ref T field, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
		{
			if ( System.Collections.Generic.EqualityComparer<T>.Default.Equals(field, value) )
			{
				return false;
			}

			OnPropertyChanging(propertyName);

			if ( null == PendingChange )
			{
				field = value;

				OnPropertyChanged(propertyName);
			}
			else if ( OnPendingChange(Resource, field, value) )
			{
				field = value;

				OnPropertyChanged(propertyName);
			}

			return true;
		}
	}
}
