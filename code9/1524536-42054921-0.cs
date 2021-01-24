    class Example
    {
        private static int _A;
        private static int GetB => _A + 1;
    
        public int GetA
        {
            get
            {
                return _A;
            }
            set
            {
                _A = value;
            }
        }
    }
