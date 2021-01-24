    public class Startup
            {    
                public Startup(IHostingEnvironment env)
                {
                    var builder = new ConfigurationBuilder()
                        .SetBasePath(env.ContentRootPath)
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
        
                    if (env.IsDevelopment())
                    {
                        builder.AddUserSecrets<Startup>();
                    }
                    else
                    {
                        builder.AddEnvironmentVariables();
                    }
        
                    Configuration = builder.Build();
                }
        
                public IConfiguration Configuration { get; }
        
                public void ConfigureServices(IServiceCollection services)
                {
                    services.Configure<MyOptions>(opt =>
                    {
                        opt.Configuration = Configuration;
                    });
        
                    services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                }
            }
