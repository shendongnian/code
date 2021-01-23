    services.AddDbContext<NewDBContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    
    services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<NewDBContext>()
                    .AddDefaultTokenProviders();
