    public class ViewModel : INotifyPropertyChanged
    {
        private string _badgeValue;
        public string BadgeValue
        {
            get { return _badgeValue; }
            set { _badgeValue = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
