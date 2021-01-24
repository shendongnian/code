    internal class NoPIILogContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = new List<JsonProperty>();
            if (!type.GetCustomAttributes(true).Any(t => t.GetType() == typeof(NoLogAttribute)))
            {
                IList<JsonProperty> retval = base.CreateProperties(type, memberSerialization);
                var excludedProperties = type.GetProperties().Where(p => p.GetCustomAttributes(true).Any(t => t.GetType() == typeof(NoLogAttribute))).Select(s => s.Name);
                foreach (var property in retval)
                {
                    if (excludedProperties.Contains(property.PropertyName))
                    {
                        property.PropertyType = typeof(string);
                        property.ValueProvider = new PIIValueProvider("PII Data");
                    }
                    properties.Add(property);
                }
            }
            return properties;
        }
    }
    internal class PIIValueProvider : IValueProvider
    {
        private object defaultValue;
        public PIIValueProvider(string defaultValue)
        {
            this.defaultValue = defaultValue;
        }
        public object GetValue(object target)
        {
            return this.defaultValue;
        }
        public void SetValue(object target, object value)
        {
        }
    }
