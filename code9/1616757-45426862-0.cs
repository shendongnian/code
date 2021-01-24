    class TimerManager
    {
        DispatcherTimer disTimer;
        Model m = Model.GetInstance();
        public TimerManager()
        {
            disTimer = new DispatcherTimer();
            disTimer.Tick += disTimer_tick;
            disTimer.Interval = new TimeSpan(0, 0, 1);
        }
        public void StartTimer()
        {
            disTimer.Start();
        }
        public void StopTimer()
        {
            disTimer.Stop();
        }
        private void disTimer_tick(object sender, EventArgs e)
        {
            m.Tick++;
        }
    }
