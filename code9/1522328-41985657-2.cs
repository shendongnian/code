    private static FluentMappingsContainer AddGenericMappings(this FluentMappingsContainer container, Type genericType, IEnumerable<Type> genericArgs)
    {
        foreach (var arg in genericArgs)
        {
            var newType = genericType.MakeGenericType(arg);
            container.Add(newType);
        }
        return container;
    }
