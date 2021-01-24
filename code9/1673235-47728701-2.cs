    public class User
    {
        public Guid Id { get; set; }
        [InverseProperty("Owner")]
        public ICollection<Photo> Photos{ get; set; }
        public Photo DefaultPhoto { get; set; }
        public Guid DefaultPhotoId { get; set; }
    }
    public class Photo
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public User Owner { get; set; }
    }
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // You may use this instead of the inverse property
            // // The One to Many relationship between
            // // User.Id (Principal End) and Photo.OwnerId
            // modelBuilder.Entity<Photo>()
            //     .HasOne(p => p.Owner)
            //     .WithMany(u => u.Photos)
            //     .HasForeignKey(p => p.OwnerId);
            // Establishes 1:0..1 relationship between
            // Photo.Id (Principal End) and User.DefaultPhoto (Dependent end)
            modelBuilder.Entity<User>()
                .HasOne(u => u.DefaultPhoto)
                .WithOne() // we leave this empty because it doesn't correspond to a navigation property in the Photos table
                .HasForeignKey<User>(u => u.DefaultPhotoId);
        }
    }
