    public void ConfigureServices(IServiceCollection services){
    ...
    var identityBuilder = services.AddIdentityCore<ApplicationUser>(user =>
                {
                    // configure identity options
                    user.Password.RequireDigit = true;
                    user.Password.RequireLowercase = false;
                    user.Password.RequireUppercase = false;
                    user.Password.RequireNonAlphanumeric = false;
                    user.Password.RequiredLength = 6;
                });
                identityBuilder = new IdentityBuilder(identityBuilder.UserType, typeof(IdentityRole), identityBuilder.Services);
                identityBuilder.AddEntityFrameworkStores<DbContext>().AddDefaultTokenProviders();
        ...
    }
