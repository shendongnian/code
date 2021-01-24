    public static class JsonContractExtensions
    {
        const string DatePropertiesName = "_date_properties_";
        public static void AddDateProperties(this JsonContract contract)
        {
            var objectContract = contract as JsonObjectContract;
            if (objectContract == null)
                return;
            var properties = objectContract.Properties.Where(p => p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?)).ToList();
            if (properties.Count > 0)
            {
                var property = new JsonProperty
                {
                    DeclaringType = contract.UnderlyingType,
                    PropertyName = DatePropertiesName,
                    UnderlyingName = DatePropertiesName,
                    PropertyType = typeof(string[]),
                    ValueProvider = new FixedValueProvider(properties.Select(p => p.PropertyName).ToArray()),
                    AttributeProvider = new NoAttributeProvider(),
                    Readable = true,
                    Writable = false,
                    // Ensure // Ensure PreserveReferencesHandling and TypeNameHandling do not apply to the synthetic property.
                    ItemIsReference = false, 
                    TypeNameHandling = TypeNameHandling.None,
                };
                objectContract.Properties.Insert(0, property);
            }
        }
        class FixedValueProvider : IValueProvider
        {
            readonly object properties;
            public FixedValueProvider(object value)
            {
                this.properties = value;
            }
            #region IValueProvider Members
            public object GetValue(object target)
            {
                return properties;
            }
            public void SetValue(object target, object value)
            {
                throw new NotImplementedException("SetValue not implemented for fixed properties; set JsonProperty.Writable = false.");
            }
            #endregion
        }
        class NoAttributeProvider : IAttributeProvider
        {
            #region IAttributeProvider Members
            public IList<Attribute> GetAttributes(Type attributeType, bool inherit) { return new Attribute[0]; }
            public IList<Attribute> GetAttributes(bool inherit) { return new Attribute[0]; }
            #endregion
        }
    }
