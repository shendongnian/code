    public static IDictionary<Type, Type> GetClosedTypesRegistrations(Type openGeneric, params Assembly[] assemblies)
    {
        if (assemblies == null || assemblies.Length == 0)
        {
            return new Dictionary<Type, Type>();
        }
    
        return assemblies
            .Where(a => !a.IsDynamic)
            .SelectMany(ReflectionUtils.GetExportedTypes)
            .SelectMany(t => t.GetInterfaces(), (t, i) => new { service = i, type = t } )
            .Where(r => r.service.IsGenericType && r.service.GetGenericTypeDefinition() == openGeneric)
            .ToDictionary(r => r.service, r => r.type);
    }
