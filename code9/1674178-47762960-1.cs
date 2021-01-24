       public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<SeedData>(); <------ This Line
    
        }
