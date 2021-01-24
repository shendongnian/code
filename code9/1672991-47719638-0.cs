    public class MyConfiguration
    {
        public bool CachingEnabled { get; set; }
        // more configuration data
    }
    public void ConfigureServices(IServiceCollection services)
    {
        // your existing configuration
        var myConfiguration = new MyConfiguration
        {
            CachingEnabled = bool.Parse(Configuration["Data:Cache"]),
            // other properties
        }
        // register the data as a singleton since it won't change
        services.AddSingleton(myConfiguration);
    }
    public class MyController : Controller
    {
        private readonly MyConfiguration configuration;
        public MyController(MyConfiguration config)
        {
            configuration = config;
        }
    }
