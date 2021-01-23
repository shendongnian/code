     protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
             .Property(t => t.Email)
            .HasColumnAnnotation(
        "Index",
        new IndexAnnotation(new IndexAttribute { IsUnique = true }));
        }
