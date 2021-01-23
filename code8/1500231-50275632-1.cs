    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Passport { get; set; }
    }
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=efbasicsappdb;Trusted_Connection=True;");
        }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasAlternateKey(u => u.Passport);
            //or: modelBuilder.Entity<User>().HasAlternateKey(u => new { u.Passport, u.Name})
        }
    }
