    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(e => e.Collection1).WithOptional();
            modelBuilder.Entity<User>().HasMany(e => e.Collection2).WithOptional();
        }
    }
