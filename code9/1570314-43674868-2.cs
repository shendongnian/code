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
                if (_flag && !value)
                {
                    lastSetFalse = DateTime.Now;
                }
                if (!_flag && value && lastSetFalse != null)
                {
                    lastStayedFalseFor = DateTime.Now - lastSetFalse;
                    //raise an event if necessary
                }
                _flag = value;
            }
        }
