    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserBook>(e => e.HasKey(c => new { c.UserId, c.BookId }));
    }
