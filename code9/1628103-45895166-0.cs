    services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
    
    services.AddAuthentication((cfg =>
    {
        cfg.DefaultScheme = IdentityConstants.ApplicationScheme;
        cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })).AddJwtBearer();
