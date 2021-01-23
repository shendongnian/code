        builder.RegisterGeneric(typeof(SQLRepository<>));
        builder.RegisterGeneric(typeof(XMLRepository<>));
        builder.RegisterGeneric(typeof(CSVRepository<>));
        var dataAccess = Assembly.GetExecutingAssembly();
        builder.RegisterAssemblyTypes(dataAccess)
             .Where(t => typeof(SQLRepository<>).IsAssignableFrom(t));
        builder.RegisterAssemblyTypes(dataAccess)
                 .Where(t => typeof(XMLRepository<>).IsAssignableFrom(t));
        builder.RegisterAssemblyTypes(dataAccess)
                 .Where(t => typeof(CSVRepository<>).IsAssignableFrom(t));
        builder.RegisterType<MainViewModel>();
