    public IConfigurationRoot Configuration { get; set; }
    public ConfigManager ConfigManager { get; set; }
    public AppConfig Config { get; set; }
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public Startup(IHostingEnvironment env)
    {
        var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json")
       .AddEnvironmentVariables();
    
        this.Configuration = builder.Build();
        this.Config = new AppConfig();
        this.Configuration.Bind(this.Config);
        this.ConfigManager = new ConfigManager(this.Config);
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IConfigManager, ConfigManager>(provider => this.ConfigManager);
        services.AddDbContext<CustomDbContext>();
        services.AddIdentity<CustomIdentity, CustomRole>(config => {
            config.SignIn.RequireConfirmedEmail = true;
        })
            .AddEntityFrameworkStores<CustomDbContext>()
            .AddDefaultTokenProviders();
        services.AddIdentityServer()
        .AddInMemoryClients(this.ConfigManager.GetClients())
        .AddInMemoryIdentityResources(this.ConfigManager.GetIdentityResources())
        .AddInMemoryApiResources(this.ConfigManager.GetApiResources())
        .AddTemporarySigningCredential()
        .AddAspNetIdentity<CustomIdentity>();
    }
