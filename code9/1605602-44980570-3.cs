    class Test
    {
        public bool? IsGood => _value != null ? _value == 1 : (bool?)null;
        private int? _value;
        public int Value
        {
            get { return _value ?? 0; }
            set { _value = value; }
        }
    
        public Test(int value)
        {
            Value = value;
        }
    }
