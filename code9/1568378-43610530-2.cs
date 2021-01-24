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
        public static RabbitListener Listener { get; set; }
        public static IApplicationBuilder UseRabbitListener(this IApplicationBuilder app)
        {
            Listener = app.ApplicationServices.GetService<RabbitListener>();
            var life = app.ApplicationServices.GetService<IApplicationLifetime>();
            life.ApplicationStarted.Register(OnStarted);
            //press Ctrl+C to reproduce if your app runs in Kestrel as a console app
            life.ApplicationStopping.Register(OnStopping);
            return app;
        }
        private static void OnStarted()
        {
            Listener.Register();
        }
        private static void OnStopping()
        {
            Listener.Deregister();    
        }
    }
