    public class MyOptions
    {
        public string ConnString { get; set; }
    }
    public void ConfigureServices(IServiceCollection services)
    { 
        // Adds services required for using options.
        services.AddOptions();
    
        services.Configure<MyOptions>(myOptions =>
        {
            myOptions.ConnString = Configuration.GetConnectionString("MyContext");
        });
        
        ...
    }
