    public class AlarmDay : INotifyPropertyChanged
    {
        public AlarmDay( string dayOfWeek )
        {
           DayOfWeek = dayOfWeek;       
        }
    
        public DayOfWeek { get; }
        private bool _isEnabled = false;
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
               _isEnabled = value;
               NotifyPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
