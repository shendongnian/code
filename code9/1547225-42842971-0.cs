    public class ValueViewModel : INotifyPropertyChanged
    {
        private string _value;
    
        public string Value
        {
            get { return _values; }
            set
            {
                if (_value == value) return;
    
                _value = value;
                OnPropertyChanged();
            }
        }
    }
