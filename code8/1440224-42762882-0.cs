    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession(options => 
                // Add any options you want here
                // EXAMPLE
                options.IdleTimeout = TimeSpan.FromSeconds(60);
            );
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseSession();
            app.UseMvcWithDefaultRoute();
        }
    }
