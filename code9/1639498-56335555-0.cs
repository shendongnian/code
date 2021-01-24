     public class Startup
        {
            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }
    
            public IConfiguration Configuration { get; }
    
            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                services.Configure<CookiePolicyOptions>(options =>
                {
                    // This lambda determines whether user consent for non-essential 
                    //cookies is needed for a given request.
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });
    
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
                services.AddDbContext<yourDbContext>(option => 
                option.UseSqlServer("Server=Your-Server-Name\\SQLExpress;Database=yourDatabaseName;Trusted_Connection=True;"));
                
                    }
            ...
            ...
        }
    
