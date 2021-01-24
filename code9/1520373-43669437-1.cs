    public static void Main(string[] args)
    {
      var host = new WebHostBuilder()
          .UseKestrel()
          .UseContentRoot(Directory.GetCurrentDirectory())
          .UseSetting("detailedErrors", "true")
          .UseIISIntegration()
          .UseStartup<Startup>()
          .CaptureStartupErrors(true)
          .Build();
      host.Run();
    }
