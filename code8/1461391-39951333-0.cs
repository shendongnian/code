    container.Register<IDbConnectionFactory>(c => new OrmLiteConnectionFactory(
        dbConnectionString, PostgreSqlDialect.Provider));
    container.Register<IAuthRepository>(c =>
        new OrmLiteAuthRepository(c.Resolve<IDbConnectionFactory>()));
    //Create any UserAuth tables that are missing
    container.Resolve<IAuthRepository>().InitSchema();
