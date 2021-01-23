    public class Blog
    {
        private string _tenantId;
    
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    
        public List<Post> Posts { get; set; }
    }
    
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
    
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>().Property<string>("TenantId").HasField("_tenantId");
    
        // Configure entity filters
        modelBuilder.Entity<Blog>().HasQueryFilter(b => EF.Property<string>(b, "TenantId") == _tenantId);
        modelBuilder.Entity<Post>().HasQueryFilter(p => !p.IsDeleted);
    }
