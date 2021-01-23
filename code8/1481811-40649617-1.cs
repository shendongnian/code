    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Configurations.Add(new BoyConfig(...));
        modelBuilder.Configuration.Add(new GirlConfig(...));
    }
    
