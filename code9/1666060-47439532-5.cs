    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddRazorPagesOptions(options => 
                {
                    options.Conventions.AddPageRoute("/Sitemap", "sitemap.xml");
                });
        }
    }
