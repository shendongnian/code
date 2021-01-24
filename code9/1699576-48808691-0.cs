    protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
    
                modelBuilder.Entity<User>().HasOne(c => c.Permissions).WithOne(i => i.User).HasForeignKey<Permissions>(b => b.UserName);
                modelBuilder.Entity<Permissions>().HasMany(c => c.NestedPermission).WithOne(c => c.Permissions).HasForeignKey(c => c.UserName);
            }
