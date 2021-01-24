    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {        
        modelBuilder.Entity<User>().Property(a => a.Id).HasKey(b => b.Id);
        modelBuilder.Entity<User>().Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    }
