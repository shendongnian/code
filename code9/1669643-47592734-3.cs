    static void Main(string[] args)
    {
        Clock.Provider = ClockProviders.Utc;
        var services = new ServiceCollection();
        IdentityRegistrar.Register(services);
        services.AddAbp<PortalServiceModule>(options =>
        {
            //Configure Log4Net logging
            options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                f => f.UseAbpLog4Net().WithConfig("log4net.config")
            );
        });
        HostFactory.Run(x =>
        {
            x.Service<PortalService>(sc =>
            {
                sc.ConstructUsing(() => new PortalService());
                sc.WhenStarted((tc, hostControl) => tc.Start(hostControl));
                sc.WhenStopped((tc, hostControl) => tc.Stop(hostControl));
            });
            x.UseLog4Net();
            x.RunAsLocalSystem();
            x.SetServiceName(PortalService.ServiceName);
            x.SetDisplayName(PortalService.ServiceDisplayName);
            x.SetDescription(PortalService.ServiceDescription);
            x.StartAutomatically();
        });
    }
