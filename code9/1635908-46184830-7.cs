    public class UrlEncodeAttribute : Attribute { }
    public class CustomResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            // Find all string properties that have a [UrlEncode] attribute applied
            // and attach an UrlEncodingValueProvider instance to them
            foreach (JsonProperty prop in props.Where(p => p.PropertyType == typeof(string)))
            {
                PropertyInfo pi = type.GetProperty(prop.UnderlyingName);
                if (pi != null && pi.GetCustomAttribute(typeof(UrlEncodeAttribute), true) != null)
                {
                    prop.ValueProvider = new UrlEncodingValueProvider(pi);
                }
            }
            return props;
        }
        protected class UrlEncodingValueProvider : IValueProvider
        {
            PropertyInfo targetProperty;
            public UrlEncodingValueProvider(PropertyInfo targetProperty)
            {
                this.targetProperty = targetProperty;
            }
            // SetValue gets called by Json.Net during deserialization.
            // The value parameter has the original value read from the JSON;
            // target is the object on which to set the value.
            public void SetValue(object target, object value)
            {
                targetProperty.SetValue(target, (string)value);
            }
            // GetValue is called by Json.Net during serialization.
            // The target parameter has the object from which to read the string;
            // the return value is the string that gets written to the JSON
            public object GetValue(object target)
            {
                string value = (string)targetProperty.GetValue(target);
                return System.Web.HttpUtility.UrlEncode(value);
            }
        }
    }
