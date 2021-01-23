    public class Startup
    {
        // ...
        public void ConfigureServices(IServiceCollection services)
        {
            // ...
            services.Configure<IPWhitelistConfiguration>(
               this.Configuration.GetSection("IPAddressWhitelistConfiguration"));
            services.AddSingleton<IIPWhitelistConfiguration>(
                resolver => resolver.GetRequiredService<IOptions<IPWhitelistConfiguration>>().Value);
            // ...
        }
     }
