    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(s => s.EventsOrganized)
                .WithRequired(c => c.Organizer)
                .WillCascadeOnDelete(false);
    
            modelBuilder.Entity<User>()
                .HasMany(s => s.EventsSubscribedFor)
                .WithMany(c => c.Participants)                
                .Map(cs =>
                {
                    cs.MapLeftKey("UserId");
                    cs.MapRightKey("EventId");
                });
    
            base.OnModelCreating(modelBuilder);
        }
