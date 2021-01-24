    public class NoTypeNameHandlingContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            // Suppress JsonPropertyAttribute.TypeNameHandling
            property.TypeNameHandling = null;
            // Suppress JsonPropertyAttribute.ItemTypeNameHandling
            property.ItemTypeNameHandling = null;
            return property;
        }
        protected override JsonContract CreateContract(Type objectType)
        {
            var contract = base.CreateContract(objectType);
            if (contract is JsonContainerContract)
            {
                // Suppress JsonContainerAttribute.ItemTypeNameHandling
                ((JsonContainerContract)contract).ItemTypeNameHandling = null;
            }
            return contract;
        }
    }
