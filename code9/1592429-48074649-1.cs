    services.AddIdentity<Automobile.Models.Account, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = false;
        })
        .AddEntityFrameworkStores<Providers.Database.EFProvider.DataContext>()
        .AddDefaultTokenProviders();
