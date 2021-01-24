    var host = new WebHostBuilder()
    .UseConfiguration(config)
    .UseKestrel()
    .UseContentRoot(Directory.GetCurrentDirectory())
    .UseIISIntegration()
    .UseStartup<Startup>()
    .Build();
    var startup = host.Services.GetService(typeof(IStartup)); // or from any other part of code using IServiceProvider.
