    public class DynamicPropertyContractResolver<TTarget> : DefaultContractResolver
    {
        readonly DynamicPropertyManager<TTarget> manager;
        readonly TTarget target;
        public DynamicPropertyContractResolver(DynamicPropertyManager<TTarget> manager, TTarget target)
        {
            if (manager == null)
                throw new ArgumentNullException();
            this.manager = manager;
            this.target = target;
        }
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            var contract = base.CreateObjectContract(objectType);
            if (objectType == typeof(TTarget))
            {
                if (contract.ExtensionDataGetter != null || contract.ExtensionDataSetter != null)
                    throw new JsonSerializationException(string.Format("Type {0} already has extension data.", typeof(TTarget)));
                contract.ExtensionDataGetter = (o) =>
                    {
                        if (o == (object)target)
                        {
                            return manager.Properties.Select(p => new KeyValuePair<object, object>(p.Name, p.GetValue(o)));
                        }
                        return null;
                    };
                contract.ExtensionDataSetter = (o, key, value) =>
                    {
                        if (o == (object)target)
                        {
                            var property = manager.Properties.Where(p => string.Equals(p.Name, key, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();
                            if (property != null)
                            {
                                if (value == null || value.GetType() == property.PropertyType)
                                    property.SetValue(o, value);
                                else
                                {
                                    var serializer = JsonSerializer.CreateDefault(new JsonSerializerSettings { ContractResolver = this });
                                    property.SetValue(o, JToken.FromObject(value, serializer).ToObject(property.PropertyType, serializer));
                                }
                            }
                        }
                    };
                contract.ExtensionDataValueType = typeof(object);
            }
            return contract;
        }
    }
