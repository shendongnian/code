    services.AddDbContext<InteractiveChoicesContext>((provider, options) =>
    {
        var config = provider.GetService<Configuration>();
        options.UseSqlServer(config.ConnectionString);
    });
