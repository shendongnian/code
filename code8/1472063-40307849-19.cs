    var assembly= Assembly.GetExecutingAssembly();
    
    builder.RegisterAssemblyTypes(assembly)
           .Where(t => t.Name.EndsWith("Repository"))
           .AsImplementedInterfaces();
