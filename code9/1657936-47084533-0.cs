    class Student
    {
       public int Id {get; set;}
       // a Student attends zero or more courses:
       public virtual ICollection<Course> Courses {get; set;}
    }
    class Course
    {
       public int Id {get; set;}
       // a Course is attended by zero or more Students:
       public virtual ICollection<Student> Students{get; set;}
    }
    class MyDbContext : DbConter
    {
        public DbSet<Student> Students {get; set;}
        public DbSet<Course> Courses {get; set;}
    }
