    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>()
            .HasOne(p => p.User)
            .WithMany(b => b.Answers)
            .HasForeignKey(s =>s.UserId) ;
        modelBuilder.Entity<Answer>()
            .HasOne(p => p.Dispute)
            .WithMany(b => b.Answers)
            .HasForeignKey(s =>s.DisputeId) ;
    }
