    public static IEnumerable<Type> GetAllTypes(Type genericType)
    {
        if (!genericType.IsGenericTypeDefinition)
            throw new ArgumentException("Specified type must be a generic type defenition.", nameof(genericType));
        return Assembly.GetExecutingAssembly()
                       .GetTypes()
                       .Where(t => t.GetInterfaces()
                                    .Any(i => i.IsGenericType &&
                                         i.GetGenericTypeDefinition().Equals(genericType)));
    }
