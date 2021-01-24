    serviceCollection
        .AddDbContext<MyDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("MyDb"),
            ServiceLifetime.Transient
        );
