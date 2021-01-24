    // Startup.cs
    public class Startup {
        private readonly ILogger _log;
        private IMainController _controller;
        public Startup(ILoggerFactory loggerFactory) {
            _log = loggerFactory.CreateLogger("Logger");            
        }
            
        public void ConfigureServices(IServiceCollection services) {
            services.AddScoped<IMainController, MainController>();
            // services.AddTransient<MainController, MainController>();
        }
    
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
                   ILoggerFactory loggerFactory, IMainController controller) {
            _controller = controller;
            //...other code removed for brevity
        }
    }
