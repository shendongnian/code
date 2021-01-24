    public class Startup
    {
    
       //Make sure you add this.
       public IConfigurationRoot Configuration { get; }
    
       public void ConfigureServices(IServiceCollection services)
       {
           ...
           
           var configSection = Configuration.GetSection("MyConfiguration");
            
           services.Configure<MyConfiguration>(configSection);
    
           //Use one of the following.            
           Services.AddScoped<MyClass>();
           Services.AddTransient<MyClass>();
           Services.AddSingleton<MyClass>();
           Services.AddInstance<MyClass>();
           ...
       }
    }
