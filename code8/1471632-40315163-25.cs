    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OneTwo>() // composite primary key
                    .HasKey(p => new { p.OneId, p.TwoId });
        modelBuilder.Entity<OneTwo>()
                    .HasRequired(a => a.One)
                    .WithMany(c => c.OneTwos)
                    .HasForeignKey(fk => fk.OneId)
                    .WillCascadeOnDelete(false);
        modelBuilder.Entity<OneTwo>()
                    .HasRequired(a => a.Two)
                    .WithMany(c => c.OneTwos)
                    .HasForeignKey(fk => fk.TwoId)
                    .WillCascadeOnDelete(false);
        // TODO: handle orphans when last asociation is deleted
    }
