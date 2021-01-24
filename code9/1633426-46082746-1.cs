    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
                    .HasOptional(p => p.Parent)
                    .WithMany(p => p.SubCategories)
                    .IsIndependent();
    }
