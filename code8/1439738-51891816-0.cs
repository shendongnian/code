    public class Startup
    {
        public Startup(IConfiguration config)
        {
            // Configuration from appsettings.json has already been loaded by
            // CreateDefaultBuilder on WebHost in Program.cs. Use DI to load
            // the configuration into the Configuration property.
            Configuration = config;
        }
    ...
    }
