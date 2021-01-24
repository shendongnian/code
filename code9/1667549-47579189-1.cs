    class Gallery : ObservableObject
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }
        private string _path;
        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
                NotifyPropertyChanged();
            }
        }
    }
