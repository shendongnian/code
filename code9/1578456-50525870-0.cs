    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var config = Configuration.GetSection("MyConfig");
            // To get the value configA
            var value = config["ConfigA"];
            // or direct get the value
            var configA = Configuration.GetSection("MyConfig:ConfigA");
            var myConfig = new MyConfig();
            // This is to bind to your object
            Configuration.GetSection("MyConfig").Bind(myConfig);
            var value2 = myConfig.ConfigA;
        }
    }
