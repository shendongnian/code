        // shadow property - primary/foreign key
        modelBuilder.Entity<UserGroup>()
            .Property<int>("IDUser");
        // shadow property - primary/foreign key
        modelBuilder.Entity<UserGroup>()
            .Property<int>("IDGroup");
        // composite primary key based on shadow properties
        modelBuilder.Entity<UserGroup>()
            .HasKey(new string[] { "IDUser", "IDGroup" });
        modelBuilder.Entity<UserGroup>()
            .HasOne(ug => ug.Group)
            .WithMany(g => g.UsersGroups);
        //.HasForeignKey(???); //what to do here ?
        modelBuilder.Entity<UserGroup>()
            .HasOne(ug => ug.User)
            .WithMany(u => u.UsersGroups);
            //.HasForeignKey(???); // what to do here ?
        base.OnModelCreating(modelBuilder);
    }
