    public class Startup
    {
        // Rest of the class here...
        public void ConfigureServices(IServiceCollection services)
        {
            // Other registrations here...
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
