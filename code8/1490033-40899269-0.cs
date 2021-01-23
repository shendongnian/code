    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOptional(u => u.Department)
            .WithMany(d => d.Users)
            .HasForeignKey(x => x.DepartmentId)
            .WillCascadeOnDelete(false);
    }
