    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationUser>()
            .HasMany(x => x.OwnedUserTasks)
            .WithOne(x => x.OwnerUser);
        modelBuilder.Entity<ApplicationUser>()
            .HasMany(x => x.ExecutedUserTasks)
            .WithOne(x => x.ExecutorUser);
    }
