    class Entry
    {
        public TimeSpan Interval { get; set; }
        public int IntervalMS
        {
            get { return Interval.TotalMilliseconds; }
            set { Interval = TimeSpan.FromMilliseconds(value); }
        }
        //other stuff...
    }
