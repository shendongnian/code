    services.AddDbContext<YourApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    
    services.AddIdentity<YourApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<YourApplicationDbContext>()
                    .AddDefaultTokenProviders();
