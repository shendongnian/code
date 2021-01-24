    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAllCoolStuff();
        }
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseAllCoolStuff();
        }
    }
