    public class Authority : INotifyPropertyChanged
    {
        private string _authorityName;
        public string AuthorityName
        {
            get { return _authorityName; }
            set { _authorityName = value; NotifyPropertyChanged(); }
        }
        private string _authorityValue;
        public string AuthorityValue
        {
            get { return _authorityValue; }
            set { _authorityValue = value; NotifyPropertyChanged(); }
        }
        private bool  _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
