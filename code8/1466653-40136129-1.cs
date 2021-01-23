    public class YourDBContext : DBContext
    {
        public YourDBContext () : base("Default")
        {
        }
    
        public DbSet<Student> Students { get; set; }
        
        public DbSet<Course> Courses { get; set; }
            
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
