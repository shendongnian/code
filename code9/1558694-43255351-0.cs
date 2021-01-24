    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    
        modelBuilder.Entity<User>()
                    .HasMany<Location>(u => u.Locations)
                    .WithMany(l => l.Students)
                    .Map(ul =>
                            {
                                cs.MapLeftKey("UserId");
                                cs.MapRightKey("LocationId");
                                cs.ToTable("UserLocation");
                            });
    
    }
