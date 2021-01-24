    private static ISessionFactory CreateSessionFactory(string path)
    {
        return Fluently.Configure()
                       .Database(SQLiteConfiguration.Standard.UsingFile(path))
                       .Mappings(m => m.FluentMappings
                       .AddFromAssembly(Assembly.GetExecutingAssembly())
                       .AddGenericMappings(typeof(GeometryModelMap<>), new[] { typeof(HouseAttributes), typeof(DungeonAttributes), typeof(FortressAttributes) }  )
                )
                .ExposeConfiguration(config => BuildSchema(config, path))
                .BuildSessionFactory();
    }
