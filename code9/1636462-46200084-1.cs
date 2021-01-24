    public class MyDbContext : DbContext
    {
         public DbSet<Teacher> Teachers {get; set;}
         public DbSet<Student> Students {get; set;}
    }
