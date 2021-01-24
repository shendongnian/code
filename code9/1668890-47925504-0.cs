    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CustomApplicationUser>().ToTable("AspNetUsers");
            modelBuilder.Entity<CustomRole>().ToTable("AspNetRoles");
            modelBuilder.Entity<CustomUserLogin>().ToTable("AspNetUserLogins");
            modelBuilder.Entity<CustomUserRole>().ToTable("AspNetUserRoles");
            modelBuilder.Entity<CustomUserClaim>().ToTable("AspNetUserClaims");
            modelBuilder.Entity<CustomApplicationUser>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<CustomRole>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<CustomUserClaim>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    }
