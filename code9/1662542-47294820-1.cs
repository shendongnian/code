    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        .....
        modelBuilder.Entity<Company>()
            .HasOne(c => c.Address)
            .WithOne(a => a.Company)
            .HasForeignKey(a => a.RelationId);
    }
