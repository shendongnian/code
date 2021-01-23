     public IContainer BootStrap()
     {
          builder.RegisterType<MainViewModel>().AsSelf().WithAttributeFiltering();
          builder.RegisterType<MainView>().AsSelf();
          builder.RegisterGeneric(typeof(XMLRepository<>)).Keyed("XMLRepository", typeof(IRepository<>));
          builder.RegisterGeneric(typeof(SQLRepository<>)).Keyed("SQLRepository", typeof(IRepository<>));
         
          return builder.Build();
     }
