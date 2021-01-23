    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>().HasMany(x => x.Students).WithMany(x=>x.Courses).Map(x=>
        {
            x.ToTable("CourseStudent");
            x.MapLeftKey("Course_ID");
            x.MapRightKey("Student_ID");
        };
    }
