    public ApplicationDbContext()
        : base("DefaultConnection", throwIfV1Schema: false)
    {
       Database.SetInitializer(
                 new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
       this.Database.Initialize(true);
    }
