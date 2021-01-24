    public class Oseba : INotifyPropertyChanged
    {
        private bool _isVisible;
        public bool visible
        {
            get { return _isVisible; }
            set { _isVisible = value; NotifyPropertyChanged("visible"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
