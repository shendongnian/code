        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //here you go
            var myvalue = Configuration["Grandfather:Father:Child"];
        }
    public IConfiguration Configuration { get; }
