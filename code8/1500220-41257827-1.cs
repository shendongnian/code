     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
