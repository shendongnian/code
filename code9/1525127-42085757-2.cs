        static ManualResetEvent _quitEvent = new ManualResetEvent(false);
        public static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
                             
            var serviceProvider = services.BuildServiceProvider();
            Console.WriteLine($"[{DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss")}] -> Worker role started");
            var listener = serviceProvider.GetService<IMessageProcessor>();
            Console.CancelKeyPress += (sender, eArgs) =>
            {
                listener.OnStop();
                Console.WriteLine($"[{DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss")}] -> Worker role finished");
                _quitEvent.Set();
                eArgs.Cancel = true;
            };
            _quitEvent.WaitOne();
        }
        private static IConfigurationRoot GetConfiguration()
        {
            // Build appsetting.json configuration
            var environment = Environment.GetEnvironmentVariable("Environment");
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables().Build();
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            IConfigurationRoot configuration = GetConfiguration();
            services.AddSingleton<IConfigurationRoot>(configuration);
            // Support typed options
            services.AddOptions();
            services.Configure<RabbitMQSettings>(configuration.GetSection("RabbitMQConfig"));
            services.AddSingleton<IQueueConsumer, QueueConsumer>();
            services.AddScoped<IMessageProcessor, MessageProcessor>();
        }
    }
