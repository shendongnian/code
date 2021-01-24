        protected void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // other entities
    
            modelBuilder.Entity<UserPost>()
               .HasKey(p => p.Id)
               .Property(p => p.Id)
               .StoreGeneratedPattern = StoreGeneratedPattern.None;
    
           // other entities
        }
