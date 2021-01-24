    public class EFDbContext : DbContext
    {    
        public DbSet<PostModel> Posts { get; set; }   
        public DbSet<ImageModel> Images { get; set; }
    }
