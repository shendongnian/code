        private class DateTimeInterval
        {
            public DateTime From { get; set; }
            public DateTime To { get; set; }
            public TimeSpan Duration
            {
                get { return (To - From); }
            }
            public DateTimeInterval() { }
            public DateTimeInterval(DateTime from, DateTime to)
            {
                From = from;
                To = to;
            }
        }
