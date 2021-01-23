	protected override void OnModelCreating(DbModelBuilder modelBuilder) 
	{ 
		modelBuilder.Entity<Test>()
			.Property(m => m.Id)
			.HasColumnType("datetime");
	}
