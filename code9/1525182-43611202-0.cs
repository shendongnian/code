    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreTimeZoneAttribute : Attribute
    {
    }
    public class IgnoreTimeZonePropertyResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            foreach (JsonProperty prop in props)
            {
                PropertyInfo pi = type.GetProperty(prop.UnderlyingName);
                if (pi != null && pi.GetCustomAttribute(typeof(IgnoreTimeZoneAttribute), true) != null)
                {
                    prop.ValueProvider = new IgnoreTimeZoneValueProvider(pi);
                }
            }
            return props;
        }
        public class IgnoreTimeZoneValueProvider : IValueProvider
        {
            private PropertyInfo _targetProperty;
            public IgnoreTimeZoneValueProvider(PropertyInfo targetProperty)
            {
                this._targetProperty = targetProperty;
            }
            // GetValue is called by Json.Net during serialization.
            public object GetValue(object target)
            {
                return _targetProperty.GetValue(target);
            }
            // SetValue gets called by Json.Net during deserialization.
            // The value parameter has the value/values read from the JSON;
            // target is the object on which to set the value/values without TimeZone info.
            public void SetValue(object target, object value)
            {
                var newValue = value;
                if (typeof(IList).IsAssignableFrom(_targetProperty.PropertyType))
                {
                    IList<object> values = value as IList<object>;
                    if (values != null)
                    {
                        for (int i = 0; i < values.Count - 1; i++)
                        {
                            var curValue = values[i];
                            if (curValue != null && curValue.GetType() == typeof(DateTime))
                            {
                                DateTimeOffset dateTime = new DateTimeOffset((DateTime)curValue);
                                values[i] = dateTime.UtcDateTime.Date;
                            }
                        }
                    }
                }
                _targetProperty.SetValue(target, newValue);
            }
        }
    }
