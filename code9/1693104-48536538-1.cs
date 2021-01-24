    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cat>()
            .HasOptional<CatLitter>(s => s.CatLitters)
            .WithMany()
            .WillCascadeOnDelete(false);
    }
