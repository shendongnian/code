    // Trigger database creation before Hangfire tries to use it.
    var initializer = new MigrateDatabaseToLatestVersion<MyDbContext, MyConfiguration>(true);
    Database.SetInitializer(initializer);
    var connectionString = this.Configuration.GetConnectionString("MyConnectionString");
    using (var dbContext = new MyDbContext(connectionString))
    {
        dbContext.Database.Initialize(false);
    }
