               var assembly = typeof(DbContextScopeFactory).Assembly;
                builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
    
                builder.RegisterAssemblyTypes(assembly)
                       .Where(t => t.Name.StartsWith("SomeInterface"))
                       .AsImplementedInterfaces();
                builder.RegisterAssemblyTypes(assembly)
                       .Where(t => t.Name.EndsWith("DbContext"))
                       .AsImplementedInterfaces(); 
