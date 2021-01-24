    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<House> Houses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"...");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House>().HasMany(x => x.Residents).WithOne(x => x.House);
        }
    }
    public class User
    {
        [Key, Required]
        public Guid UserId { get; set; }
        public virtual House House { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
    }
    public class House
    {
        [Key, Required]
        public Guid HouseId { get; set; }
        public List<User> Residents { get; set; }
        [Required]
        public virtual User HouseOwner { get; set; }
    }
