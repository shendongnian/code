    namespace MusicStore
    {
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                ...
                services.AddSingleton<ISystemClock, SystemClock>();
                ...
            }
        }
    }
