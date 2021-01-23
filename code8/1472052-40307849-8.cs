    var dataAccess = Assembly.GetExecutingAssembly();
    
    builder.RegisterAssemblyTypes(dataAccess)
           .Where(t => t.Name.EndsWith("Repository"))
           .AsImplementedInterfaces();
