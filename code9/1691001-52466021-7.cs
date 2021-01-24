    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<AvailabilityRule>()
            .Property(b => b.Event )
            .HasJsonConversion();
    }
