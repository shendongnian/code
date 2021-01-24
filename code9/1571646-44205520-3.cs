    public partial class FileMeta : INotifyPropertyChanged
    {
        private System.Windows.Visibility _loading;
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public System.Windows.Visibility Loading
        {
            get
            {
                return _loading;
            }
            set
            {
                if (_loading != value)
                {
                    _loading = value;
                    RaisePropertyChanged("Loading");
                }
            }
        }
    }
