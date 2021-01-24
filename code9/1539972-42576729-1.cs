    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    modelBuilder.Entity<Student>()
                .HasMany<Course>(s => s.Courses)
                .WithMany(c => c.Students)
                .Map(cs =>
                        {
                            cs.MapLeftKey("StudentRefId");
                            cs.MapRightKey("CourseRefId");
                            cs.ToTable("StudentCourse");
                        });
    }
    
