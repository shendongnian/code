     public void ConfigureServices(IServiceCollection services)
     {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
     }
