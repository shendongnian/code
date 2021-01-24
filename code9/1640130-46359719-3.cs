    public class User : INotifyPropertyChanged
    {
        private string _machineName;
        private string _status;
        public string MachineName
        {
            set
            {
                if (!value.Equals(_machineName))
                {
                    _machineName = value;
                    NotifyPropertyChanged();
                }
            }
            get { return _machineName; }
        }
        public string Status
        {
            set
            {
                if (!value.Equals(_status))
                {
                    _status = value;
                    NotifyPropertyChanged();
                }
            }
            get { return _status; }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
