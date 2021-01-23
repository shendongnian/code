    class NestedValueProvider : IValueProvider
    {
        readonly IValueProvider outerProvider;
        readonly IValueProvider innerProvider;
        
        public NestedValueProvider(IValueProvider outerProvider, IValueProvider innerProvider)
        {
            if (outerProvider == null || innerProvider == null)
                throw new ArgumentNullException();
            this.outerProvider = outerProvider;
            this.innerProvider = innerProvider;
        }
        public void SetValue(object target, object value)
        {
            throw new NotImplementedException();
        }
        public object GetValue(object target)
        {
            var innerTarget = outerProvider.GetValue(target);
            if (innerTarget == null)
                return null;
            return innerProvider.GetValue(innerTarget);
        }
    }
    class CustomResolver : CamelCasePropertyNamesContractResolver
    {
        // Using an inner resolver prevents difficulties with recursion.
        readonly CamelCasePropertyNamesContractResolver innerResolver = new CamelCasePropertyNamesContractResolver();
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var jsonProperty = base.CreateProperty(member, memberSerialization);
            if (!jsonProperty.PropertyType.IsPrimitive && jsonProperty.PropertyType != typeof(string) && jsonProperty.Readable)
            {
                var innerContract = innerResolver.ResolveContract(jsonProperty.PropertyType);
                if (innerContract is JsonObjectContract)
                {
                    var objectContract = (JsonObjectContract)innerContract;
                    var idProperty = objectContract.Properties.GetClosestMatchProperty(ResolvePropertyName("Id"));
                    if (idProperty != null && idProperty.Readable && (innerResolver.ResolveContract(idProperty.PropertyType) is JsonPrimitiveContract))
                    {
                        jsonProperty = new JsonProperty
                        {
                            PropertyName = ResolvePropertyName(member.Name + "Id"),
                            Readable = true,
                            PropertyType = idProperty.PropertyType,
                            ValueProvider = new NestedValueProvider(jsonProperty.ValueProvider, idProperty.ValueProvider),
                        };
                    }
                }
                // Possibly handle innerContract is JsonArrayContract?
                // Possibly handle innerContract is JsonDictionaryConract?
            }
            return jsonProperty;
        }
    }
