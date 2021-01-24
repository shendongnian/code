        static void Main()
        {
            var builder = new ContainerBuilder();
            // 1) Every class needs logger
            // 2) Logger needs AppSettingsProvider which needs AppEnvironmentProvider
            // 3) Listener needs AppSettingsProvider which needs AppEnvironmentProvider
            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
            builder.RegisterType<AppSettingsProvider>()
                .As<IAppSettingsProvider>()
                .SingleInstance()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
            builder.RegisterType<AppEnvironmentProvider>().As<IAppEnvironmentProvider>().SingleInstance();
            builder.RegisterType<Listener>().As<IListener>().SingleInstance();
            var container = builder.Build();
            var listener = container.Resolve<IListener>();
            Console.WriteLine(listener.Do());
            Console.Read();
        }
        public interface IListener
        {
            string Do();
        }
        public class Listener : IListener
        {
            IAppSettingsProvider appSettingsProvider;
            public Listener(IAppSettingsProvider appSettingsProvider)
            {
                // this class needs IAppSettingsProvider to get some settings
                // but not actually used on this example.
                this.appSettingsProvider = appSettingsProvider;
            }
            public string Do()
            {
                return "doing something using circular Dependency";
            }
        }
        public interface ILogger
        {
            void Log(string message);
        }
        public class Logger : ILogger
        {
            IAppSettingsProvider appSettingsProvider;
            public Logger(IAppSettingsProvider appSettingsProvider)
            {
                this.appSettingsProvider = appSettingsProvider;
            }
            public void Log(string message)
            {
                // simplified
                if (this.appSettingsProvider.GetSettings())
                {
                    Console.WriteLine(message);
                }
            }
        }
        public interface IAppSettingsProvider
        {
            // will return a class, here simplified to bool
            bool GetSettings();
        }
        public class AppSettingsProvider : IAppSettingsProvider
        {
            ILogger logger;
            public AppSettingsProvider()
            {
                
            }
            public ILogger Logger { get; set; }
            public bool GetSettings()
            {
                Logger.Log("Getting app settings");
                return true;
            }
        }
        public interface IAppEnvironmentProvider
        {
            string GetEnvironment();
        }
        public class AppEnvironmentProvider : IAppEnvironmentProvider
        {
            ILogger logger;
            public AppEnvironmentProvider(ILogger logger)
            {
                this.logger = logger;
            }
            public string GetEnvironment()
            {
                this.logger.Log("returning current environment");
                return "dev";
            }
        }
