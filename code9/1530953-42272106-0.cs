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
            set { _a = value; NotifyPropertyChanged(); D = _a + _b; }
        }
        private double _b;
        public double B
        {
            get { return _b; }
            set { _b = value; NotifyPropertyChanged(); D = _a + _b; }
        }
        private double _d;
        public double D
        {
            get { return _d; }
            set { _d = value; NotifyPropertyChanged(); }
        }
        public double C { get; set; }
    }
