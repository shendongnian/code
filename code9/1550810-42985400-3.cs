    // option mapping classes
    public class FacebookOptions
    {
        // maybe string here
        public bool IsEnabled { get; set; }
        public string AppId { get; set; }
        public string AppSecret { get; set; }
    }
    
    public class GoogleOptions
    {
        // maybe string here
        public bool IsEnabled { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
    // load configuration
    public Startup(IHostingEnvironment env)
    {
        // Set up configuration sources.
        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
        Configuration = builder.Build();
    }
    // map the configuration to object
    public void ConfigureServices(IServiceCollection services)
    {
        // Adds services required for using options.
        services.AddOptions();
        // Register the IConfiguration instance which options binds against.
        services.Configure<FacebookOptions>(Configuration.GetSection("Facebook"));
        services.Configure<GoogleOptions>(Configuration.GetSection("Google"));
        // Add framework services.
        services.AddMvc();
    }
