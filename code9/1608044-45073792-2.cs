     class MyDbContext : DbContext
    {
        public DbSet<School> Schools {get; set;}
        public DbSet<Student> Students {get; set;}
        public DbSet<Class> Classes {get; set;}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Entity Class should be put in table Classes
            modelBuilder.Entity<Class>().ToTable("Classes");
            // property Student.ClassId in column "ClassId1"
            modelBuilder.Entity<Student>()               // from class Student
                .Property(student => student.ClassId)    // take property ClassId
                .HasColumnName("ClassId1");              // give it the column name "ClassId1"
      
        }
    }
    
