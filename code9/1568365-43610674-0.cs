    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students {get; set;}
        public DbSet<Teacher> Teachers {get; set;}
        public DbSet<ClassRoom> ClassRooms {get; set;}
        ...
    }
