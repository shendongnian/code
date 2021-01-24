    modelBuilder.Entity<ApplicationUser>()
                .HasMany(c => c.AddedFriends)
                .WithMany(c => c.AddingFriends)
                .Map(m =>
                {
                    m.ToTable("Friends");
                    m.MapLeftKey("AddedUser");
                    m.MapRightKey("AddingUser");
                });
    modelBuilder.Entity<ApplicationUser>()
                .HasMany(c => c.BloquedUsers)
                .WithMany(c => c.BloquingUsers)
                .Map(m =>
                {
                    m.ToTable("Bloqueds");
                    m.MapLeftKey("BloquingUser");
                    m.MapRightKey("BloquedUser");
                });
