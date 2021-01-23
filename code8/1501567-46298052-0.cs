    public class Startup
    {
        private readonly ILogger<Startup> _logger;
        public IConfiguration Configuration { get; }
        public Startup(ILogger<Startup> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            _logger.LogInformation("ConfigureServices called");
            // …
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            _logger.LogInformation("Configure called");
            // …
        }
    }
