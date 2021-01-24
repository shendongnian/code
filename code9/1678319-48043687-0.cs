    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseSessionMiddleware();
    
            // other middleware registrations...
            app.UseWebApi();
        }
    }
