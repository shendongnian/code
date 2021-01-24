    builder.RegisterType<PrepareConnectionInterceptor>()
           .AsSelf();
    builder.RegisterType<SQLiteConnection>()
            .As<IDbConnection>()
            .EnableInterfaceInterceptors()
            .InterceptedBy(typeof(PrepareConnectionInterceptor)); 
