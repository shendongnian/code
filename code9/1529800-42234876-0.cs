    public class PlanningResult : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private double _a;
        public double A
        {
            get { return _a; }
            set { _a = value; NotifyPropertyChanged(); NotifyPropertyChanged("D"); }
        }
        private double _b;
        public double B
        {
            get { return _b; }
            set { _b = value; NotifyPropertyChanged(); NotifyPropertyChanged("D"); }
        }
        public double D { get { return _a + _b; } }
    }
