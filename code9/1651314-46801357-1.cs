    services.AddDbContext<TecTacDbContext>(opts =>
    {
    	// This is how you get the connectionString from your appsettings
    	opts.UseSqlServer(Configuration.GetConnectionString("TecTac"));
    	opts.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    });
