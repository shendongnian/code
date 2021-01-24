    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
                    .HasMany(c => c.Locations)
                    .WithMany(l => l.Cars)
                    .Map(cl =>
                            {
                            cl.MapLeftKey("CarId");
                            cl.MapRightKey("LocationId");
                            cl.ToTable("YOUR_TABLE_NAME");
                            });
    }
