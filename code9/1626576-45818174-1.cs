    class MyDbContext : DbContext
    {
        public DbSet<Student> Students {get; set;}
        public DbSet<ExchangeStudent> ExchangeStudents {get; set;}
        protected override OnModelCreating(...)
        {   // configure Student and ExcahngeStudent as TPC,
            // if needed define primary key
            modelBuilder.Entity<Student>()
            .HasKey(student => student.Id)
            .Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Students");
            });
            modelBuilder.Entity<ExchangeStudent>()
            .HasKey(student => student.Id)
            .Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("ExchangeStudents");
            });
        }
