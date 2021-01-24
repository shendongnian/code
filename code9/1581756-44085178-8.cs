    protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Item>()
                    .HasKey(t => t.itemId)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
		base.OnModelCreating(modelBuilder);
	}
