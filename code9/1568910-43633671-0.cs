    public class Startup
    {
        [...]
    
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddMvc();
            services.AddAuthentication();
            [...]
        }
    
        public void Configure([...])
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseOpenIdConnectServer(options =>
            {
                [code of example]
            });
            app.UseOAuthValidation();
            app.UseMvc();
        }
    }
