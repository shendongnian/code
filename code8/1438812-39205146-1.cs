    class Entry
    {
        public TimeSpan Interval { get; set; }
        public int IntervalMS
        {
            get { return (int)Interval.TotalMilliseconds; }
            set { Interval = TimeSpan.FromMilliseconds(value); }
        }
        //other stuff...
    }
