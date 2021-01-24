    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Foo>().Ignore(t => t.IsDeleted);
       base.OnModelCreating(modelBuilder);
    }
