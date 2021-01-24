    namespace Test_Tool.ViewModels
	{
		public class MainPageViewModel : INotifyPropertyChanged
		{
			private bool _isDirect = false;
			public bool IsDirect
			{
				get
				{
					return _isDirect;
				}
				set
				{
					set { SetField(ref _isDirect, value, "isDirect"); }
				}
			}
			public event PropertyChangedEventHandler PropertyChanged;
		    protected virtual void OnPropertyChanged(string propertyName)
		    {
			    PropertyChangedEventHandler handler = PropertyChanged;
			    if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		    }
		    protected bool SetField<T>(ref T field, T value, string propertyName)
		    {
			    if (EqualityComparer<T>.Default.Equals(field, value)) return false;
			    field = value;
			    OnPropertyChanged(propertyName);
			    return true;
		    }
		}
	}
