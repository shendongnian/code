    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Configure UserId as PK for Sub_User
        modelBuilder.Entity<Sub_User>()
            .HasKey(e => e.UserId);
            
        // Configure UserId as FK for Sub_User
        modelBuilder.Entity<User>()
                    .HasOptional(u => u.SubUser) 
                    .WithRequired(su => su.UserId); 
    
    }
