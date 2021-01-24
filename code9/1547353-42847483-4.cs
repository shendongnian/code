Defines the IsMatch which allows you to define if the object property matches the json property.
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public abstract class JsonDeserializationPropertyMatchAttribute : Attribute
    {
        protected JsonDeserializationPropertyMatchAttribute() { }
    
        public abstract bool IsMatch(JProperty jsonProperty);
    }
