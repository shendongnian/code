    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Worker>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
    }
 
