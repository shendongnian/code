	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		// ...
		
		builder.Entity<MyEntity>()
			.Property(e => e.ConcurrencyStamp)
				.ForNpgsqlHasColumnName("xmin")
				.ForNpgsqlHasColumnType("xid")
				.ValueGeneratedOnAddOrUpdate()
				.IsConcurrencyToken();
	}
