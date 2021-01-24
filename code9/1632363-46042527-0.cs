    new ObjectDataItem { TypeName = typeof(int).FullName, Value = 3.ToString() }
    ...
    public struct ObjectDataItem 
    {
        public string TypeName;
        public string Value;
        [XmlIgnore]
        public Type RealType
        {
            get
            {
                return Type.GetType(TypeName);
            }
        }
    }
