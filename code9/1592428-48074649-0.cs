    services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = false;
        })
        .AddEntityFrameworkStores<Providers.Database.EFProvider.DataContext>()
        .AddDefaultTokenProviders();
