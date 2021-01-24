    abstract class ClockBase
    {
        private Timer _timer = new Timer(); // Create the timer.
        public event EventHandler<ClockTickEventArgs> Tick;
        public ClockBase()
        {
            _timer.Tick += Timer_Tick; // Subscribe to timer tick event.
            _timer.Interval = 1000; // Let the clock tick every 1000 ms.
            _timer.Start(); // Start the timer.
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            string timeString = FormatTime(DateTime.Now); // Format the current date time.
            Tick?.Invoke(this, new ClockTickEventArgs(timeString)); // Fire the Tick event.
        }
        // This will be implemented by concrete clocks.
        protected abstract string FormatTime(DateTime time);
    }
