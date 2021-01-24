        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(x => x.OwnedUserTask)
                .WithOne(x => x.OwnerUser);
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(x => x.ExecutedUserTask)
                .WithOne(x => x.ExecutorUser);
        }
