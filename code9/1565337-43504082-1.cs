    class Product : INotifyPropertyChanged
    {
        public int id { get; set; }
        public string title { get; set; }
        private string _folder;
        public string MyProperty
        {
            get { return _folder; }
            set { _folder = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
