    namespace DL.STS.Host
    {
        public class Startup
        {
            ...
            public void ConfigureServices(IServiceCollection services)
            {
                string dbConnectionString = _configuration.GetConnectionString("appDbConnection");
                // Add Identity service using ASP.NET Core Identity
                services.AddIdentityService(dbConnectionString);
                services
                    .AddRouting(options => options.LowercaseUrls = true)
                    .AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
                services
                    .AddIdentityServer()
                    .AddEFConfigurationStore(dbConnectionString)
                    ...;                
            }
            ...
        }
    }
