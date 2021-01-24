    class MyDbContext : DbContext
    {
        public DbSet<Employee> Employees {get; set;}
        public DbSet<Project> Projects {get; set;}
        public DbSet<Tool> Tools {get; set;}
    }
