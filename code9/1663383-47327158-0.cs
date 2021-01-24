      protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    
          modelBuilder.Entity<tblUserProfile>()//IdentityUserLogin
                .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId })
                .ToTable("tblUserProfile");// Database Table Nam    
                
                modelBuilder.Entity<tblAccessRole>()//IdentityUserRole
                .HasKey(r => new { r.UserId, r.RoleId })
                    .ToTable("tblAccessRole");// Database Table Name
        }
