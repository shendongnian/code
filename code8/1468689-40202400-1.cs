    public class Today
    {
        private DateTime _CurrentDateTime;
        private Month _month;
        public int LastDayOfCurrentMonth { get { return _month.LastDayOfCurrentMonth; }}
        private class Month
        {
            private Today _parent;
            public Month(Today parent)
            {
                _parent = parent;
            }
            public int LastDayOfCurrentMonth
            {
                get
                {
                    return DateTime.DaysInMonth(_parent._CurrentDateTime.Year, _parent._CurrentDateTime.Month);
                }
            }
        }
    
        public Today()
        {
            _month = new Month(this);
            _CurrentDateTime = DateTime.Today;
        }
        public override string ToString()
        {
            return _CurrentDateTime.ToShortDateString();
        }
    }
