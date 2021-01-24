    class TakeData
    {
        public List<TakeItAll> Data { get; set; }
    }
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
                PureData = new IntData { pKey = pKey, Entity = Entity, Attribute = Attribute, iValue = iValue };
            }
        }
        private string _sValue;
        public string sValue
        {
            get => _sValue;
            set
            {
                _sValue = value;
                PureData = new StrData { pKey = pKey, Entity = Entity, Attribute = Attribute, sValue = sValue };
            }
        }
        public IPureData PureData { get; private set; }
    }
    interface IPureData
    {
        object pKey { get; set; }
        string Entity { get; set; }
        string Attribute { get; set; }
    }
    class IntData : IPureData
    {
        public object pKey { get; set; }
        public string Entity { get; set; }
        public string Attribute { get; set; }
        public int iValue { get; set; }
    }
    class StrData : IPureData
    {
        public object pKey { get; set; }
        public string Entity { get; set; }
        public string Attribute { get; set; }
        public string sValue { get; set; }
    }
