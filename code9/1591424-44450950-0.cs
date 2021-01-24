     public static Container Configure(IServiceCollection services)
     {
        var container = new Container( config  => 
          {
              config.Scan(s =>
                {
                    s.TheCallingAssembly();
                    s.WithDefaultConventions();
                    s.AddAllTypesOf<IStartupTask>();
                    s.LookForRegistries();
                    s.AssembliesAndExecutablesFromApplicationBaseDirectory();
                });
              config.Populate(services);  
           });
     
        return container;
    }
