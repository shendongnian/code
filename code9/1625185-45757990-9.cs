    class MyDbContext : DbContext
    {
        public DbSet<Student> Students {get; set;}
        public DbSet<Teacher> Teachers {get; set;}
        public DbSet<Parent> Parents {get; set;}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Map(student =>
            {
                student.MapInheritedProperties();
                student.ToTable(nameof(MyDbContext.Students));
            });
 
            modelBuilder.Entity<Teacher>().Map(teacher =>
            {
                teacher.MapInheritedProperties();
                teacher.ToTable(nameof(MyDbContext.Teachers));
            });
            // etc. for Parent
        }
    }
