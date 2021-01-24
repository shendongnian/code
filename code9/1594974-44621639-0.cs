    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    class JsonPropertyNameByTypeAttribute : Attribute
    {
        public string PropertyName { get; set; }
        public Type ObjectType { get; set; }
        public JsonPropertyNameByTypeAttribute(string propertyName, Type objectType)
        {
            PropertyName = propertyName;
            ObjectType = objectType;
        }
    }
