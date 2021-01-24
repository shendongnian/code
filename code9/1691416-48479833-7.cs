    modelBuilder.Entity<Post>()
        .HasOne(e => e.Content).WithOne()
        // or .WithOne(c => c.Post) if there is a back reference
        .HasForeignKey<PostContent>(e => e.ID);
    modelBuilder.Entity<Post>().ToTable("Posts");
    modelBuilder.Entity<PostContent>().ToTable("Posts");
