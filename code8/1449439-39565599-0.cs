     protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure Code First to ignore PluralizingTableName convention 
            // If you keep this convention then the generated tables will have pluralized names. 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<StoreGeneratedIdentityKeyConvention>();
            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRole");             
            modelBuilder.Entity<IdentityUserRole>().ToTable("AspNetUserRole");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("AspNetUserLogin");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("AspNetUserClaim");
            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUser");
           
        }
