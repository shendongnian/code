    class Example
    {
        private static int _A;
        private static int _B;
    
        public int GetA
        {
            get
            {
                return _A;
            }
            set
            {
                _A = value;
                _B = _A + 1;
            }
        }
    
        public int GetB
        {
            get
            {
                return _B;
            }
    
        }
    }
