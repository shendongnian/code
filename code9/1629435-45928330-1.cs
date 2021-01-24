    class Program {
        static void Main(string[] args) {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            var app = serviceProvider.GetService<Application>(); // Got null value
            Task.Run(() => app.Run()).Wait();
        }
        private static void ConfigureServices(IServiceCollection services) {
            ILoggerFactory loggerFactory = new LoggerFactory()
                 .AddConsole() // Error!
                 .AddDebug();
            services.AddSingleton(loggerFactory); // Add first my already configured instance
            services.AddLogging(); // Allow ILogger<T>
            IConfigurationRoot configuration = GetConfiguration();
            services.AddSingleton<IConfigurationRoot>(configuration);
            // Support typed Options
            var myOptions = new MyOptions();
            configuration.GetSection("MyOptions").Bind(myOptions);
            services.AddSingleton<MyOptions>(myOptions);
            services.AddTransient<Application>();
        }
        private static IConfigurationRoot GetConfiguration() {
            return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddXmlFile("App.config", optional: true).Build();
        }
        public class MyOptions {
            public string Name { get; set; }
        }
        public class Application {
            ILogger _logger;
            MyOptions _settings;
            public Application(ILogger<Application> logger, MyOptions settings) {
                _logger = logger;
                _settings = settings;
            }
            public async Task Run() {
                try {
                    _logger.LogInformation($"This is a console application for {_settings.Name}");
                } catch (Exception ex) {
                    _logger.LogError(ex.ToString());
                }
            }
        }
    }
