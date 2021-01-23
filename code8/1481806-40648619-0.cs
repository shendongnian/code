    public class MyUser
    {
        public int Id { get; set; }
        public virtual MyUserProfile Profile { get; set; }
    }
    public class MyUserProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    class MyContext : DbContext
    {
        public DbSet<MyUser> Users { get; set; }
        public DbSet<MyUserProfile> Profiles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyUser>()
                .HasOptional(x => x.Profile)
                .WithRequired();
        }
    }
