    class ClockTickEventArgs : EventArgs
    {
        public ClockTickEventArgs(string timeString)
        {
            this.TimeString = timeString;
        }
        public string TimeString { get; private set; }
    }
