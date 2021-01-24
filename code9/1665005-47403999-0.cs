    modelBuilder.Entity<User>(entity =>
    {
        entity.Property(e => e.Id)
            .HasColumnName("id")
            .HasColumnType("int(11)")
            .ValueGeneratedNever(); // <-- the problem
    }
