    class A : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public bool isLocalSearchEnabled = false;
        public bool IsLocalSearchEnabled
        {
             get { return isLocalSearchEnabled ;}
             set { isLocalSearchEnabled  = value; this.OnPropertyChanged("IsLocalSearchEnabled");
        }
    }
