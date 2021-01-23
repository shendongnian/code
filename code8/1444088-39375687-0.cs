    public class Data : INotifyPropertyChanged
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
        private bool _isActive;
        public bool IsActive 
        {
            get { return _isActive; }
            set
            {
                if (value == _isActive)
                {
                    return;
                }
                _isActive = value;
                NotifyPropertyChanged("IsActive");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
