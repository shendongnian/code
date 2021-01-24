    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PrivateMessage>()
                    .HasRequired(m => m.MessageFromProfile)
                    .WithMany(t => t.FromPrivateMessages)
                    .HasForeignKey(m => m.MessageFromUserId)
                    .WillCascadeOnDelete(false);
        modelBuilder.Entity<PrivateMessage>()
                    .HasRequired(m => m.MessageToProfile)
                    .WithMany(t => t.ToPrivateMessages)
                    .HasForeignKey(m => m.MessageToUserId)
                    .WillCascadeOnDelete(false);
    }
