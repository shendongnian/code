    public static void Main(string[] args)
    {
        var host = WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(builder =>
            {
                builder.AddIniFile("foo.ini");
            })
            .UseStartup<Startup>()
            .Build();
    
        host.Run();
    }
