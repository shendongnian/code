    public class TestContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("user")
                .HasKey(_ => _.Id);
            modelBuilder.Entity<User>()
                .Property(_ => _.Id).HasColumnName("id");
            modelBuilder.Entity<User>()
                .Property(_ => _.UserName).HasColumnName("username"); // Add also HasMaxLength here
        }
    }
