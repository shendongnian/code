    // ...other code removed for brevity
    // in Program.cs
    public static void Main(string[] args)
    {
        BuildWebHost(args).Run();
    }
    
    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
                services.AddScoped<IMainController, MainController>()
            )
            .UseStartup<Startup>()
            .Build();
