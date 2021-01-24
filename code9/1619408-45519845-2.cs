    using (var context = new ApplicationDbContext())
     {
        Database.SetInitializer(
                  new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        context.Database.Initialize(true);
     }
