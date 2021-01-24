    public class ClockViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ClockViewModel()
        {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += TimerTick;
            timer.Start();
        }
        private void TimerTick(object sender, EventArgs e)
        {
            var t = DateTime.Now.TimeOfDay;
            HoursAngle = t.TotalHours * 30 % 360; // fractional hours
            MinutesAngle = t.Minutes * 6; // full minutes
            SecondsAngle = t.Seconds * 6; // full seconds
        }
        private double hoursAngle;
        public double HoursAngle
        {
            get { return hoursAngle; }
            set
            {
                hoursAngle = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(HoursAngle)));
            }
        }
        private double minutesAngle;
        public double MinutesAngle
        {
            get { return minutesAngle; }
            set
            {
                minutesAngle = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(MinutesAngle)));
            }
        }
        private double secondsAngle;
        public double SecondsAngle
        {
            get { return secondsAngle; }
            set
            {
                secondsAngle = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(SecondsAngle)));
            }
        }
    }
