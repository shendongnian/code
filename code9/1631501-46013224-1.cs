    // Startup.cs
    public class Startup {
        private ILogger _log;
        private IMainController _controller;
        public Startup() {
                        
        }
            
        public void ConfigureServices(IServiceCollection services) {
            services.AddScoped<IMainController, MainController>();
            // services.AddTransient<MainController, MainController>();
        }
    
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
                   ILoggerFactory loggerFactory, IMainController controller) {
            _log = loggerFactory.CreateLogger("Logger");
            _controller = controller;
            //...other code removed for brevity
        }
    }
