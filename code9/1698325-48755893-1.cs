    builder.RegisterAssemblyTypes(typeof(IDbFactory).GetTypeInfo().Assembly).AsImplementedInterfaces();
    builder.RegisterAssemblyTypes(typeof(IResolver).GetTypeInfo().Assembly).AsImplementedInterfaces();
    builder.RegisterAssemblyTypes(typeof(ISampleRepository).GetTypeInfo().Assembly).AsImplementedInterfaces();
    builder.RegisterAssemblyTypes(typeof(IService).GetTypeInfo().Assembly).AsImplementedInterfaces();
    builder.RegisterAssemblyTypes(typeof(ISampleService).GetTypeInfo().Assembly).AsImplementedInterfaces();
