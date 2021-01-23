    modelBuilder.Entity<AB>()
                .HasKey(e => new { e.AId, e.BId});
    modelBuilder.Entity<AB>()
                .HasOne(e => e.A)
                .WithMany(e => e.ABs)
                .HasForeignKey(e => e.AId)
                .OnDelete(DeleteBehavior.Cascade); // <= This entity has cascading behaviour on deletion
    modelBuilder.Entity<AB>()
                .HasOne(e => e.B)
                .WithMany(e => e.ABs)
                .HasForeignKey(e => e.BId)
                .OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion
