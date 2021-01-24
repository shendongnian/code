    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    class DefaultAttribute : Attribute
    {
        public object Value;
        public DefaultAttribute(object value)
        {
            this.Value = value;
        }
    }
