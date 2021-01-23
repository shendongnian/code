    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable(tableName: "users");
        modelBuilder.Entity<WorkPlace>().ToTable(tableName: "workplaces");
        modelBuilder.Entity<User>()
            .HasRequired(user => user.Place)
            .WithMany(place => place.Users);
    }   
