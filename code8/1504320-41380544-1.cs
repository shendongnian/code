    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        //one-to-many 
        modelBuilder.Entity<User>()
                    .HasRequired<UserDefaultModel>(s => s.UserDefaultModel) // User entity requires UserDefaultModel 
                    .WithMany(u => u.Users); // UserDefaultModel entity includes many User entities
    
    }
