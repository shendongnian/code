    var interfaceType = typeof(IList<string>);
    var ctor = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(a =>
        {
            try
            {
                return a.GetTypes();
            }
            catch
            {
                return new Type[0];
            }
        })
        .Select(t => interfaceType.IsGenericType && t.IsGenericType && interfaceType.GetGenericArguments().Length == t.GetGenericArguments().Length && t.GetGenericArguments().All(a => a.GetGenericParameterConstraints().Length == 0) ? t.MakeGenericType(interfaceType.GetGenericArguments()) : t)
        .Where(interfaceType.IsAssignableFrom)
        .SelectMany(t => t.GetConstructors())
        .FirstOrDefault(c => c.GetParameters().Length == 0);
