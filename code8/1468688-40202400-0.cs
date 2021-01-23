    public class Today
    {
        private DateTime _CurrentDateTime;
    
    
        public class Month
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
    
        }
    }
