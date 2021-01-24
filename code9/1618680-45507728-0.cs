    private static ISessionFactory CreateSessionFactory()
    {
        return Fluently.Configure()
            .Database(FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2012
            .ConnectionString(c => c
            .FromConnectionStringWithKey("connectionStringKey")))
            .Mappings(m =>
                 m.FluentMappings.AddFromAssemblyOf<Program>())
            .ExposeConfiguration(BuildSchema)
            .BuildSessionFactory();
    }
