    public static IDictionary<Type, Type> GetClosedTypesRegistrations(Type openGeneric, params Assembly[] assemblies)
    {
        if (assemblies == null || assemblies.Length == 0)
        {
            return new Dictionary<Type, Type>();
        }
    
        var dict = new Dictionary<Type, Type>();
        foreach (var assembly in assemblies)
        {
            if (!assembly.IsDynamic)
            {
                var types = ReflectionUtils.GetExportedTypes(assembly);
    
                var q = from type in types
                        from i in type.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == openGeneric
                        select new { service = i, type = type };
    
                foreach (var elem in q)
                    dict.Add(elem.service, elem.type);
            }
        }
    
        return dict;
    }
