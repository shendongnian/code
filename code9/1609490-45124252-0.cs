        private DateTime _lastprocessed;
        public DateTime lastprocessed
        {
            get
            {
                return _lastprocessed.ToLocalTime().ToUniversalTime();
            }
            set
            {
                _lastprocessed = value;
            }
        }
