    class MyDbContext : DbContext
    {
        public DbSet<School> Schools {get; set;}
        public DbSet<Student> Students {get; set;}
        public DbSet<Class> Classes {get; set;}
    }
