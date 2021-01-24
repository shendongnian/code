    var assembly =  Assembly.GetExecutingAssembly();// or your target Assembly
    builder.RegisterAssemblyTypes(assembly)
         .Where(t => t.Name.EndsWith("Repository") || t.Name.EndsWith("Service"))
         .AsImplementedInterfaces().InstancePerDependency()
         .PropertiesAutowired();
    
