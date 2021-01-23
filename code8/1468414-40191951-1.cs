    public DbSet<Department> Departments { get; set; }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // other mapping code
        modelBuilder.Entity<Department>()
          .HasOptional(x => x.ParentDepartment)
          .WithMany(x => x.ChildDepartments)
          .HasForeignKey(x => x.DepartmentId);
        // other mapping code
    }
