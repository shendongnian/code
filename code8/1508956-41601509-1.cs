    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Child>().HasKey(a => a.EntityId);
        mb.Entity<Child>().HasOne(c => c.Entity).WithMany().HasForeignKey("ParentId");
        mb.Entity<OtherChild>().HasKey(a => a.EntityId);
        mb.Entity<OtherChild>().HasOne(c => c.Entity).WithMany().HasForeignKey("ParentId");
    }
