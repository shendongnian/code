    public class Today
    {
        private DateTime _CurrentDateTime;
        private Month _month;
        public int LastDayOfCurrentMonth { get { return _month.LastDayOfCurrentMonth; }}
        // You can make this class private to avoid any direct interaction
        // from the external clients and mediate any functionality of this
        // class through properties of the Today class. 
        // Or you can declare a public property of type Month in the Today class
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
