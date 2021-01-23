    public class Startup
    {
        public IConfiguration Configuration {get;set;}
        public Startup(IHostingEnvironment env)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("routes.json", optional: false, reloadOnChange: true);
            
            Configuration = configurationBuilder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }
        public void Configure(IApplicationBuilder app)
        {
            var routeBuilder = new RouteBuilder(app);
    
            routeBuilder.MapGet("{route}", context => 
            {
                var routeMessage = Configuration.AsEnumerable()
                    .FirstOrDefault(r => r.Key == context.GetRouteValue("route")
                    .ToString())
                    .Value;
                
                var defaultMessage = Configuration.AsEnumerable()
                    .FirstOrDefault(r => r.Key == "default")
                    .Value;
    
                var response = (routeMessage != null) ? routeMessage : defaultMessage;
    
                return context.Response.WriteAsync(response);
            });
    
            app.UseRouter(routeBuilder.Build());
        }
    }
