    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Map Entities to their tables.
        modelBuilder.Entity<MyUser>().ToTable("Users");
        // Set AutoIncrement-Properties
        modelBuilder.Entity<MyUser>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        // Override some column mappings that do not match our default
        modelBuilder.Entity<MyUser>().Property(r => r.UserName).HasColumnName("username");
        modelBuilder.Entity<MyUser>().Property(r => r.PasswordHash).HasColumnName("password");
        modelBuilder.Entity<MyUser>().Property(r => r.Id).HasColumnName("lgn_key");
        modelBuilder.Entity<MyUser>().Property(r => r.Email).HasColumnName("primaryEmail");
    }
