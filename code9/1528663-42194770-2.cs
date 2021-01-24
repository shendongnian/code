    static IProvider GetProviderUsingTypeConstructor(string name)
    {
        Type providerType = null;
        if (providerTypeMap.TryGetValue(name, out providerType))
        {
            var constructor = providerType.GetConstructor(Type.EmptyTypes);
            return (IProvider)constructor.Invoke(null);
        }
        //throw new ArgumentOutOfRangeException("name", "Provider not found.");
        return null;
    }
