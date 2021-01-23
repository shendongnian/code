      var builder = new ContainerBuilder();
      builder.RegisterGeneric(typeof(SQLRepository<>));
      builder.RegisterGeneric(typeof(XMLRepository<>));
      builder.RegisterGeneric(typeof(CSVRepository<>));
      builder.RegisterGeneric(typeof(SQLRepository<>))
                   .As(typeof(IRepository<>))
                   .InstancePerLifetimeScope();
      builder.RegisterGeneric(typeof(XMLRepository<>))
                   .As(typeof(IRepository<>))
                   .InstancePerLifetimeScope();
      builder.RegisterGeneric(typeof(CSVRepository<>))
                   .As(typeof(IRepository<>))
                   .InstancePerLifetimeScope();
