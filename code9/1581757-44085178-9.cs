    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>()
                    .HasKey(t => t.itemID)
                    .Property(x =>x.itemID)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
    	base.OnModelCreating(modelBuilder);
    }
