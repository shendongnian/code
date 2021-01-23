        public interface IBloggingContext : IDisposable
    {
        DbSet<Blog> Blogs { get; set; }
        DbSet<Post> Posts { get; set; }
    }
    public class BloggingContext : DbContext, IBloggingContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("blogging.db");
            //optionsBuilder.UseSqlite("Data Source=blogging.db");
        }
    }
    public interface IBloggingContextFactory
    {
        IBloggingContext CreateContext();
    }
    public class BloggingContextFactory : IBloggingContextFactory
    {
        private Func<IBloggingContext> _contextCreator;
        public BloggingContextFactory(Func<IBloggingContext> contextCreator)// This is fine with .net and unity, this is treated as factory function, but creating problem in .netcore service provider
        {
            _contextCreator = contextCreator;
        }
        public IBloggingContext CreateContext()
        {
            return _contextCreator();
        }
    }
    public class Blog
    {
        public Blog()
        {
            CreatedAt = DateTime.Now;
        }
        public Blog(int id, string url, string deletedBy) : this()
        {
            BlogId = id;
            Url = url;
            DeletedBy = deletedBy;
            if (!string.IsNullOrWhiteSpace(deletedBy))
            {
                DeletedAt = DateTime.Now;
            }
        }
        public int BlogId { get; set; }
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }
        public ICollection<Post> Posts { get; set; }
        public override string ToString()
        {
            return $"id:{BlogId} , Url:{Url} , CreatedAt : {CreatedAt}, DeletedBy : {DeletedBy}, DeletedAt: {DeletedAt}";
        }
    }
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
