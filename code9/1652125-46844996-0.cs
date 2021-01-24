    [AttributeUsage(AttributeTargets.Property)]
    class MyCustomJsonPropertyAttribute : Attribute
    {
        public string PropertyName { get; protected set; }
        public MyCustomJsonPropertyAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
