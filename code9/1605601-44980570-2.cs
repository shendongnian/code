    class Test
    {
        public bool? IsGood { get; private set; }
        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                IsGood = _value == 1;
            }
        }
    
        public Test(int value)
        {
            Value = value;
        }
    }
