    var sessionFactory = Fluently.Configure()
      .Database(/* database config */)
      .Mappings(m =>
        m.AutoMappings
          .Add(AutoMap.AssemblyOf<Products>())
          .Add(AutoMap.AssemblyOf<Orders>())
       )
      .BuildSessionFactory();
