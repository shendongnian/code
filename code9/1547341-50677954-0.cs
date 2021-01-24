    private Config Config { get; }
    public Startup(IConfiguration Configuration)
    {
    	Config = Configuration.Get<Config>();
    }
