    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Configure GuestItemId as PK for GuestItem
        modelBuilder.Entity<GuestItem>()
            .HasKey(e => e.GuestItemId);
    
        // Configure GuestItemId as FK for GuestItem
        modelBuilder.Entity<GuestItem>()
                    .HasOptional(s => s.Invitation) 
                    .WithRequired(ad => ad.GuestItemId); 
    
    }
