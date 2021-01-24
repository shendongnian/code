    private readonly IHostingEnvironment _env;
    public IConfigurationRoot Configuration { get; }
    
    
    public Startup(IHostingEnvironment env)
    {
        _env = env;
        var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
          .AddEnvironmentVariables();
    
        Configuration = builder.Build();
    }
            public void ConfigureServices(IServiceCollection services)
            {
                services.Configure<IdentityServerSettings>(Configuration.GetSection("IdentityServerSettings"));
    ......
