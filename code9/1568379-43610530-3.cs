    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<RabbitListener>();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseRabbitListener();
        }
    }
        
    public static class ApplicationBuilderExtentions
    {
        //the simplest way to store a single long-living object, just for example.
        private static RabbitListener _listener { get; set; }
        public static IApplicationBuilder UseRabbitListener(this IApplicationBuilder app)
        {
            _listener = app.ApplicationServices.GetService<RabbitListener>();
            var lifetime = app.ApplicationServices.GetService<IApplicationLifetime>();
            lifetime.ApplicationStarted.Register(OnStarted);
            //press Ctrl+C to reproduce if your app runs in Kestrel as a console app
            lifetime.ApplicationStopping.Register(OnStopping);
            return app;
        }
        private static void OnStarted()
        {
            _listener.Register();
        }
        private static void OnStopping()
        {
            _listener.Deregister();    
        }
    }
