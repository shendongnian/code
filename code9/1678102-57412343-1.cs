    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tip>()
            .HasIndex(entity => new { entity.TipsterId, entity.Home, entity.Away, entity.Prediction })
            .HasName("IX_UniqueTip")
            .IsUnique();
    }
