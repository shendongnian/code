{
  "Logging": {
    "IncludeScopes": false,
    "LogLevel": {
      "System": "Information",
      "Microsoft": "Information"
    }
  },
  "MyConfig": "My Config Value for staging."
}
Use **`Configuration["config_var"]`** to retrieve any configuration value.
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
