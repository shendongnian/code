    public void ConfigureServices(IServiceCollection services)
        {
            var lgr = LogManager.GetCurrentClassLogger();
            var logger = new NlogLogger(lgr);
            services.AddSingleton<ILogger>(provider => logger);
            services.AddSingleton<IMachineConfigFactory, MachineConfigFactory>();
            services.AddSingleton<IMemoryCacheService, MemoryCacheService>();
            services.AddSingleton<IServerManagerService, ServerManagerService>();
            services.AddSingleton<ISubscriberServerHubService, SubscriberServerHubService>();
            services.AddSingleton<IPurgeService, PurgeService>();
            var configuration = GetConfiguration(option);
            services.AddSingleton(configuration);
            services.AddOptions();
            services.Configure<HostConfig>(configuration.GetSection("HostConfig"));
            services.AddSingleton<ServerManager>();
            services.AddSingleton<CacheManagerService>();
            return services;
        }
