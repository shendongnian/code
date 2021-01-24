    IConfiguration globalConfig = new Configuration();
    IConfiguration localConfig = new Configuration();
    
    container.RegisterInstance<IConfiguration>("globalConfig", globalConfig);
    container.RegisterInstance<IConfiguration>("localConfig", localConfig);
        
    ...
    container.RegisterType<IConfiguration, Configuration>("localConfig", new ContainerControlledLifetimeManager());
    container.RegisterType<IConfiguration, Configuration>("globalConfig", new ContainerControlledLifetimeManager());
