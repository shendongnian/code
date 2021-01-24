    public class Startup {
        public Startup(IHostingEnvironment env) {
            HostingEnvironment = env;
        }
    
        public IHostingEnvironment HostingEnvironment { get; private set; }
    
        public void ConfigureServices(IServiceCollection services) {
            if (HostingEnvironment.IsDevelopment()) {
                // Development configuration
                services.AddDbContext<DbContext>(options => options.UseMySQL("..."));
            } else {
                // Staging/Production configuration
                services.AddDbContext<pluginwebContext>(options => options.UseSqlServer("...");
            }
        }
    }
