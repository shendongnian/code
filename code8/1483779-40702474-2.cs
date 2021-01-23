    public class LastRefreshedViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private int _lastRefreshTime;
        public string LastRefreshTimeString
        {
            get
            {
                return _lastRefreshTime == 0 ? "Never" : _lastRefreshTime + " min";
            }
        }
        public int LastRefreshTime
        {
            get { return _lastRefreshTime; }
            set
            {
                {
                    if (value == _lastRefreshTime)
                    {
                        return;
                    }
                    _lastRefreshTime = value;
                    NotifyPropertyChanged("LastRefreshTimeString");
                    NotifyPropertyChanged("LastRefreshTime");
                }
            }
        }
        public LastRefreshedViewModel()
        {
            _lastRefreshTime = 0;
        }
        public void Update()
        {
            LastRefreshTime++;
        }
        public void Reset()
        {
            LastRefreshTime = 1;
        }
    }
