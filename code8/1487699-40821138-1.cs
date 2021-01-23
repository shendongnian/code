    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserTag>()
            .HasKey(x => new { x.User, x.TagId });
        modelBuilder.Entity<UserTag>()
            .HasOne(x => x.User)
            .WithMany(y => y.UserTags)
            .HasForeignKey(x => x.UserId);
        modelBuilder.Entity<UserTag>()
            .HasOne(x => x.Tag)
            .WithMany(y => y.UserTags)
            .HasForeignKey(x => x.TagId);
    }
