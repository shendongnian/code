    public class MonthlyReport : INotifyPropertyChanged
    {
        private bool _checked;
        public bool Checked
        {
            get { return _checked; }
            set { _checked = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
