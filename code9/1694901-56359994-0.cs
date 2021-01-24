    public class Startup
    {
        public Startup()
        {
        }
    
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<TestMiddleware>();
            services.AddScoped<TestService>();
        }
    
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<TestMiddleware>();
        }
    }
