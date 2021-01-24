     protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    
          modelBuilder.Entity<IdentityUserLogin>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId })
                .ToTable("AspNetUserLogins");// Database Table Name   
    
        }
