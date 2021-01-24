    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; } 
    }
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; } 
    }
    public class BloggingContext : DbContext
    {
        public BloggingContext() : base() { } // constructor using config file
        public BloggingContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
        public BloggingContext(DbConnection connection) : base(connection, true) { }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
