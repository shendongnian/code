    {
        private bool _courageous;
        private bool _cowardly;
        public bool Courageous
        {
            get { return _courageous; }
            set
            {
                _courageous = value;
                _cowardly = !value;
            }
        }
        public bool Cowardly
        {
            get { return _cowardly; }
            set
            {
                _cowardly = value;
                _courageous = !value;
            }
        }
    }
