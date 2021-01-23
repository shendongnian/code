    public class YourDataObject : INotifyPropertyChanged
    {
        private bool _check;
        public bool Check
        {
            get { return _check; }
            set { _check = value; NotifyPropertyChanged(); }
        }
        private string _user;
        public string User
        {
            get { return _user; }
            set { _user = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
