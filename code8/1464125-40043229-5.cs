    public class MyViewModel1 : INotifyPropertyChanged
    {
        private List<string> _availableNames;
        private string _name;
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
    
        public List<string> AvailableNames
        {
            get
            {
                return _availableNames;
            }
            set
            {
                _availableNames = value;
                OnPropertyChanged();
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
