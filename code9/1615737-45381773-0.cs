    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _ElapsedTimeString;
        public string ElapsedTimeString
        {
            get { return _ElapsedTimeString; }
            set
            {
                if (_ElapsedTimeString != value)
                {
                    _ElapsedTimeString = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ElapsedTimeString"));
                }
            }
        }
      
        // ....
    }
