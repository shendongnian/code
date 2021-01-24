        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            StaticConfig = configuration;
        }
        public static IConfiguration StaticConfig { get; private set; }
