    services.AddDbContext<ApplicationDbContext>(options => {
        // Configure the context to use Microsoft SQL Server.
        options.UseSqlServer(configuration["Data:DefaultConnection:ConnectionString"]);
        // Register the entity sets needed by OpenIddict.
        // Note: use the generic overload if you need
        // to replace the default OpenIddict entities.
        options.UseOpenIddict();
    });
    // Register the OpenIddict services.
    services.AddOpenIddict()
        // Register the Entity Framework stores.
        .AddEntityFrameworkCoreStores<ApplicationDbContext>();
