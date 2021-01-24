    public class Startup  
    {    
      public void ConfigureServices(IServiceCollection services)
      {    
        services.AddTransient<IYourService, YourService>();
      }
    }
    
    public class StartupTesting  
    {    
      public void ConfigureServices(IServiceCollection services)
      {   
        services.AddTransient<IYourService, YourMockedService>();
      }
    }
    
    
    var assemblyName = typeof(Startup).GetTypeInfo().Assembly.FullName;
    //var assemblyName = typeof(StartupTesting).GetTypeInfo().Assembly.FullName;
    
    var host = new WebHostBuilder()  
        .UseKestrel()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseStartup(assemblyName)
        .Build();
    
    host.Run();
