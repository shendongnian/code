    var humanTypes = typeof(IHuman).
                GetTypeInfo().Assembly.DefinedTypes
                .Where(t => typeof(IHuman).GetTypeInfo().IsAssignableFrom(t.AsType()) && t.IsClass)
                .Select(p => p.AsType());
            
    foreach(var humanType in humanTypes )
    {
        services.AddSingleton(humanType);
    }
