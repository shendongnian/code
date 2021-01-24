    // Register DataModel as IDataModel 
    // Register Service Class as IService
    builder.RegisterAssemblyTypes(typeof(IServiceAssembly).GetTypeInfo().Assembly)
        .Where(t => t.Name.EndsWith("DM") || t.Name.EndsWith("Service"))
        .AsImplementedInterfaces();
