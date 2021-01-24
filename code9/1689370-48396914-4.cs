    class TakeItAll
    {
        public object pKey { get; set; }
        public string Entity { get; set; }
        public string Attribute { get; set; }
        private int _iValue;
        public int iValue
        {
            get => _iValue;
            set
            {
                _iValue = value;
                ValType = typeof(string);
            }
        }
        private string _sValue;
        public string sValue
        {
            get => _sValue;
            set
            {
                _sValue = value;
                ValType = typeof(int);
            }
        }
        public Type ValType { get; private set; }
    }
