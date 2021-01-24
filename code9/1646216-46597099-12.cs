    // Note you may need more than one registration if you are spanning
    // multiple assemblies.
    builder.RegisterAssemblyTypes(typeof(INotification).Assembly)
       .Where(x => typeof(INotification).IsAssignableFrom(x))
       .AsImplementedInterfaces();
