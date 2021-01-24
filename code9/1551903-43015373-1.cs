	public class Startup
	{
		// ...
		
        public IConfigurationRoot Configuration { get; }
		
        public void ConfigureServices(IServiceCollection services)
        {
			// ...
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<BaseDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("BaseConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddMvc();
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<BaseDbContext>();
			// ...
        }
		
		// ...
    }
