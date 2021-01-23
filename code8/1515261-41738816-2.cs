    public static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();
        WebProtocolSettings settings_Web = new WebProtocolSettings();
        config.GetSection("WebProtocolSettings").Bind(settings_Web);
        var host = new WebHostBuilder()
                .UseIISIntegration()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseUrls(settings_Web.Url + ":" + settings_Web.Port)
                .Build()
        host.Run();
    }
