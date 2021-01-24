    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonClub>()
            .HasKey(pc => new { pc.PersonId, pc.ClubId });
        modelBuilder.Entity<PersonClub>()
            .HasOne(pc => pc.Person)
            .WithMany(p => p.PersonClubs)
            .HasForeignKey(pc => pc.PersonId);
        modelBuilder.Entity<PersonClub>()
            .HasOne(pc => pc.Club)
            .WithMany(c => c.PersonClubs)
            .HasForeignKey(pc => pc.ClubId);
    }
