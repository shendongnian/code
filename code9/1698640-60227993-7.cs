    private static IServiceProvider BuildDi(IConfiguration configuration) {
        /* this is being called early inside my command line application ("console application") */
    
        string defaultConnectionStringValue = string.Empty; /* get this value from configuration */
    
        ////setup our DI
        IServiceCollection servColl = new ServiceCollection()
            ////.AddLogging(loggingBuilder => loggingBuilder.AddConsole())
    
            /* THE BELOW TWO ARE THE ONES THAT TRIPPED ME UP.  */
            .AddTransient<IMySpecialObjectDomainData, MySpecialObjectEntityFrameworkDomainDataLayer>()
        .AddTransient<IMySpecialObjectManager, MySpecialObjectManager>()
    
        /* so the "ServiceLifetime.Transient" below................is what you will find most commonly on the internet search results */
         # if (MY_ORACLE)
            .AddDbContext<ProvisioningDbContext>(options => options.UseOracle(defaultConnectionStringValue), ServiceLifetime.Transient);
         # endif
    
         # if (MY_SQL_SERVER)
            .AddDbContext<ProvisioningDbContext>(options => options.UseSqlServer(defaultConnectionStringValue), ServiceLifetime.Transient);
         # endif
    
        servColl.AddSingleton <IMySpecialObjectThatSpawnsThreads,        MySpecialObjectThatSpawnsThreads>();
    
        ServiceProvider servProv = servColl.BuildServiceProvider();
    
        return servProv;
    }
