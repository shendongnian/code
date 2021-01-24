        public DateTime lastSetFalse { get; private set; }
        public TimeSpan lastStayedFalseFor { get; private set; }
        private bool _flag;
        public bool Flag
        {
            get
            {
                return _flag;
            }
            set
            {
                if (_flag == true && value == false)
                {
                    lastSetFalse = DateTime.Now;
                }
                if (_flag == false && value == true && lastSetFalse != null)
                {
                    lastStayedFalseFor = DateTime.Now - lastSetFalse;
                    //raise an event if necessary
                }
                _flag = value;
            }
        }
