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
