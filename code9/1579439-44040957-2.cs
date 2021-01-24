    public class Clock : INotifyPropertyChanged
    {
        DispatcherTimer Timer = new DispatcherTimer();
        public string _time { get; set; }
        public string Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged("Time");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler hander = PropertyChanged;
            if (hander != null)
            {
                hander(this, new PropertyChangedEventArgs(name));
            }
        }
        public void InitClock()
        {
            Timer.Tick += Timer_Tick;
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }
        private void Timer_Tick(object sender, object e)
        {
            Time = DateTime.Now.ToString("h:mm:ss tt");
        }
    }
