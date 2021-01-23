    public static void Main(string[] args)
    {
        ...
        var host = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(directoryPath)
            .UseStartup<Startup>()
            .Build();
        Startup.Container.RegisterSingleton<MyService>();
        Startup.Container.Verify();
        ...
    }
