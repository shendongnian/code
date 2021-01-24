    public class ItemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    
        string _first;
        public string First
        {
            get
            {
                return _first;
            }
    
            set
            {
                _first = value;
                OnPropertyChanged("First");
            }
        }
    
        string _second;
        public string Second
        {
            get
            {
                return _second;
            }
    
            set
            {
                _second = value;
                OnPropertyChanged("Second");
            }
        }
    }
