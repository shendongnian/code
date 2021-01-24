    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton(new DbSettings(...));
        }
    }
