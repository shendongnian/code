    builder.RegisterApiControllers(assemblies.ToArray())
           .InstancePerRequest()
           .EnableClassInterceptors();
    
    builder.RegisterAssemblyTypes(assemblies.ToArray())
           .As<IInterceptor>(); 
