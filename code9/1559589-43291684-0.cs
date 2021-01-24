	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		
		modelBuilder.Entity<User>()
			.Property(a => a.Id)
			.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
	}
