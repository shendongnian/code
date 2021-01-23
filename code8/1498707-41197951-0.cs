    public static void Main(string[] args)
    {
        ...
        var host = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(directoryPath)
            .UseStartup<Startup>()
            .Build();
        // Don't forget to remove the Verify() call from within the Startup.
        Startup.Container.Verify();
        ...
    }
