    class Teacher
    {
        public int Id {get; set;}
        // a Teacher has zero or more Students:
        public virtual ICollection<Student> Students {get; set;}
        ...
    }
    class Student
    {
        public int Id {get; set;}
        // a Student has exactly one Teacher, via foreign key TeacherId
        public int TeacherId {get; set;}
        public virtual Teacher Teacher {get; set;}
        ...
    }
    class MyDbContext : DbContext
    {
        public DbSet<Teacher> Teachers {get; set;}
        public DbSet<Student> Students {get; set;}
    }
