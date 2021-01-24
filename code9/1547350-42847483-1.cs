Defines an attribute which allows you to have multiple names associated to a property. The IsMatch implementation simply loops through them and tries to find a match.
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class JsonDeserializationNameAttribute : JsonDeserializationPropertyNameMatchAttribute
    {
        public string[] PropertyNames { get; private set; }
    
        public JsonDeserializationNameAttribute(params string[] propertyNames)
        {
            this.PropertyNames = propertyNames;
        }
    
        public override bool IsMatch(JProperty jsonProperty)
        {
            return PropertyNames.Any(x => String.Equals(x, jsonProperty.Name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
