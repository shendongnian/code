    class Student
    {
        public int Id {get; set}
        public Datetime Birthday {get;set;}
    }
    class MyDbContext : DbContext
    {
        public DbSet<Student> Students {get; set;}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
	    {
            // all DateTime are DateTime2
            modelBuilder.Properties<DateTime>().Configure(p => p.HasColumnType("datetime2"));
            ...
        }
    }
