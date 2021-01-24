    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Match>()
            .HasOptional(c => c.SourceMatch1 )
            .WithMany()
            .HasForeignKey(c => c.RelatedMatchId);
    }
