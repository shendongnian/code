    public struct ObjectDataItem
    {
        public object Value;
        [XmlIgnore]
        public Type Type
        {
            get
            {
                return Value.GetType();
            }
        }
    }
