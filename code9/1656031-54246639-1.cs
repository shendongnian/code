    public Startup(IConfiguration configuration, ILogger<Startup> logger)
    {
        Configuration = configuration;
        this.logger = logger;
    }
    public IConfiguration Configuration { get; }
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        logger.LogWarning("Starting up");
