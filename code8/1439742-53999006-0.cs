    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    internal static IConfiguration Configuration { get; private set; }
