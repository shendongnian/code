	public class ViewModel : ObservableObject
	{
		private object _myProperty;
        public object MyProperty
        {
            get { return _myProperty; }
            set
            {
                if (_myProperty != value)
                {
                    _myProperty = value;
                    NotifyPropertyChanged();
                }
            }
        }
		private object _anotherProperty;
        public object AnotherProperty
        {
            get { return _anotherProperty; }
            set
            {
                if (_anotherProperty != value)
                {
                    _anotherProperty = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("MyProperty");
                }
            }
        }
	}
