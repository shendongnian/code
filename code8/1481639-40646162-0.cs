    public class CustomResolver : DefaultContractResolver
    {
        const string IndicatorKeyword = "Specified";
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            Dictionary<string, JsonProperty> dict = props.ToDictionary(p => p.UnderlyingName);
            foreach (JsonProperty prop in props)
            {
                string name = prop.UnderlyingName;
                if (name.Length > IndicatorKeyword.Length && name.EndsWith(IndicatorKeyword))
                {
                    // We have an indicator property; ignore it for serialization purposes
                    prop.Ignored = true;
                    // Find the corresponding target property, e.g. "XyzSpecified" => "Xyz"
                    string targetName = name.Substring(0, name.Length - IndicatorKeyword.Length);
                    JsonProperty coProp = null;
                    if (dict.TryGetValue(targetName, out coProp))
                    {
                        // Create a value provider for the property pointing to the
                        // "real" target and indicator properties from the containing type
                        PropertyInfo realTarget = type.GetProperty(targetName);
                        PropertyInfo realIndicator = type.GetProperty(name);
                        coProp.ValueProvider = new CustomValueProvider(realTarget, realIndicator);
                    }
                }
            }
            return props;
        }
        class CustomValueProvider : IValueProvider
        {
            PropertyInfo targetProperty;
            PropertyInfo indicatorProperty;
            public CustomValueProvider(PropertyInfo targetProperty, PropertyInfo indicatorProperty)
            {
                this.targetProperty = targetProperty;
                this.indicatorProperty = indicatorProperty;
            }
            // GetValue is called by Json.Net during serialization.
            // The target parameter has the object from which to read the value;
            // the return value is what gets written to the JSON
            public object GetValue(object target)
            {
                bool isSpecified = (bool)indicatorProperty.GetValue(target);
                return isSpecified ? targetProperty.GetValue(target) : null;
            }
            // SetValue gets called by Json.Net during deserialization.
            // The value parameter has the value read from the JSON;
            // target is the object on which to set the value.
            public void SetValue(object target, object value)
            {
                bool isSpecified = value != null;
                indicatorProperty.SetValue(target, isSpecified);
                if (isSpecified) targetProperty.SetValue(target, value);
            }
        }
    }
