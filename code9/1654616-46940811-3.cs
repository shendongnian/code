        public class Program
        {
            public static void Main(string[] args)
            {
                BuildWebHost(args).Run();
            }
            public static IWebHost BuildWebHost(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .Build();            
        }
        public class Startup
        {
            private readonly IHostingEnvironment _currentEnv;
            public IConfiguration Configuration { get; private set; }
            public Startup(IConfiguration configuration, IHostingEnvironment env)
            {
                _currentEnv = env;
                Configuration = configuration;
            }
        }
