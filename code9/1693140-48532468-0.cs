    container.Register<IDbConnectionFactory>(
        new OrmLiteConnectionFactory(connString, SqlServerDialect.Provider)
        {
            ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current)
        });
