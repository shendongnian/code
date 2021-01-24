    public class TypeDescriptorContractResolver : DefaultContractResolver
    {
        public TypeDescriptorContractResolver()
        {
        }
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            var contract = base.CreateObjectContract(objectType);
            
            if (contract.ExtensionDataGetter != null || contract.ExtensionDataSetter != null)
                throw new JsonSerializationException(string.Format("Type {0} already has extension data.", objectType));
            contract.ExtensionDataGetter = (o) =>
            {
                return TypeDescriptor.GetProperties(o).OfType<PropertyDescriptor>().Select(p => new KeyValuePair<object, object>(p.Name, p.GetValue(o)));
            };
            contract.ExtensionDataSetter = (o, key, value) =>
            {
                var property = TypeDescriptor.GetProperties(o).OfType<PropertyDescriptor>().Where(p => string.Equals(p.Name, key, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();
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
            };
            contract.ExtensionDataValueType = typeof(object);
            return contract;
        }
    }
