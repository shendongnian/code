    class CustomResolver : DefaultContractResolver
    {
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            var contract = base.CreateObjectContract(objectType);
            if (objectType == typeof(Thing))
            {
                contract.CreatorParameters.Clear();
                // For safety, specify the order concretely.
                contract.CreatorParameters.AddProperty(contract.Properties["Id"]); // Use nameof() in latest version.
                contract.CreatorParameters.AddProperty(contract.Properties["Name"]); // Use nameof() in latest version.
                contract.OverrideCreator = new ObjectConstructor<object>(Thing.Create2);
            }
            return contract;
        }
    }
