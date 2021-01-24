        private class RequireObjectPropertiesContractResolver : DefaultContractResolver
        {
            protected override JsonObjectContract CreateObjectContract(Type objectType)
            {
                var contract = base.CreateObjectContract(objectType);
                contract.ItemRequired = Required.AllowNull;
                return contract;
            }
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                var properties = base.CreateProperties(type, memberSerialization);
                foreach (var p in properties)
                {
                    p.Required = Required.AllowNull;
                }
                return properties;
            }
        }
