    var resolverTypes = .AppDomain.CurrentDomain.GetAssemblies()
        .Where(a => !a.IsDynamic) // Exclude dynamic assemblies
        .Select(a => a.GetTypes())
        .SelectMany(t => t) // flatten Types for each assembly into one
        .Select(t => t.GetTypeInfo())
        .Where(t => 
            t.ImplementedInterfaces.Any(i =>
                i.IsGenericType && i.GetGenericTypeDefinition()
                                 .IsAssignableFrom(typeof(IValueResolver<,,>))))
        .Select(t => new
        {
            Inteface = t.ImplementedInterfaces.First(i =>
                i.IsGenericType && i.GetGenericTypeDefinition()
                                 .IsAssignableFrom(typeof(IValueResolver<,,>))),
            Type = t
        });
    var container = new UnityContainer();
    foreach (var resolverType in resolverTypes)
    {
        container.RegisterType(resolverType.Inteface, resolverType.Type);
        var resolver = container.Resolve(typeof(IValueResolver<Class1, Class2, string>));
        Debug.Assert(resolver.GetType() == typeof(Class1ToClass2ValueResolver));
    }
