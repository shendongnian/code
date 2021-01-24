    public static void Main(string[] args) {
      BuildWebHost(args).Run();
    }
    
    public static IWebHost BuildWebHost(string[] args) =>
      WebHost.CreateDefaultBuilder(args)
        .UseKestrel()
        .UseStartup<Startup>()
        .Build();
    }
