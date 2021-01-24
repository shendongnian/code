    DataContainer.Test = "testing";
    var host = new WebHostBuilder()
                .ConfigureServices(s => { s.AddSingleton(typeof(DataContainer)); })
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseConfiguration(configuration) // config added here
                .UseStartup<Startup>()
                .Build();
