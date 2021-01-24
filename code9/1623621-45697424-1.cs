    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "myauth1";
            })
    
           .AddCookie("myauth1");
           .AddCookie("myauth2");
        }
    
        public void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication();
    
            // ...
        }
    }
