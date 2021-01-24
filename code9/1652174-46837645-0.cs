    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    
        modelBuilder.Entity<Student>()
                    .HasMany<Course>(s => s.Courses)
                    .WithMany(c => c.Students)
                    .Map(cs =>
                            {
                                cs.MapLeftKey("StudentId");
                                cs.MapRightKey("CourseId");
                                cs.ToTable("StudentCourse"); // this is mappingtable
                            });
    
    }
