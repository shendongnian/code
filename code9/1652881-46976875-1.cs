        services.AddDbContext<XPContext>(builder =>
            builder
            .UseSqlServer(Configuration["TryDBConnectionString"])
            .ReplaceService<IAsyncQueryProvider, LoggingQueryProvider>()
        );
