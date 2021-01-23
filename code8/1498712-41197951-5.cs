    public static void Main(string[] args)
    {
        var container = new Container();
        container.Options.DefaultScopedLifestyle = new AspNetRequestLifestyle();
        IWebHost host = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .ConfigureServices(services =>
            {
                // Configure framework components
                services.AddOptions();
            })
            .Configure(app =>
            {
                app.UseSimpleInjectorAspNetRequestScoping(container);
                // Apply cross-wirings:
                container.RegisterSingleton(
                    app.ApplicationServices.GetRequiredService<ILoggerFactory>());
            })
            .UseStartup<Startup>()
            .Build();
        container.RegisterSingleton<MyService>();
        container.RegisterSingleton(host);
        container.Verify();
        ServiceBase.Run(Startup.Container.GetInstance<MyService>());
    }
