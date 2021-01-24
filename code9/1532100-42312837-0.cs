    static void Main(string[] args)
    {
        var types = GetTypes(typeof(Manager));
        
        foreach (var propertyInfo in types)
        {
            Console.WriteLine("{0,-20}{1,-20}{2}", 
                propertyInfo.PropertyType.Name, 
                propertyInfo.DeclaringType?.Name,
                propertyInfo.Name);
        }
    }
    public static List<PropertyInfo> GetTypes(Type type)
    {
        if (type.Module.ScopeName == "CommonLanguageRuntimeLibrary" || // prevent getting properties of built-in type
        type == type.DeclaringType)                                    // prevent stack overflow
        {
            return new List<PropertyInfo>();
        }
        
        const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
        List<PropertyInfo> result = type
            .GetProperties(flags)
            .SelectMany(p => new[] {p}.Concat(GetTypes(p.PropertyType)))
            .ToList();
        return result;
    }
