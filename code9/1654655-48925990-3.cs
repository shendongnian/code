    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration config)
        {
    		Environment = env;
            Configuration = config;
            var myconfig = Configuration["MyConfig"];
        }
    
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }
    }
