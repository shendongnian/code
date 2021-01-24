    static class TimerManager
    {
        static DispatcherTimer disTimer;
        static Model m = Model.GetInstance();
        public static void Initialize()
        {
            disTimer = new DispatcherTimer();
            disTimer.Tick += disTimer_tick;
            disTimer.Interval = new TimeSpan(0, 0, 1);
        }
        public static void StartTimer()
        {
            disTimer.Start();
        }
        public static void StopTimer()
        {
            disTimer.Stop();
        }
        private static void disTimer_tick(object sender, EventArgs e)
        {
            m.Tick++;
        }
    }
