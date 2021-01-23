    public class BloggingContext : DbContext
    {
        public BloggingContext()
            : base(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\tmks.dldp\documents\visual studio 2013\Projects\CodeFirstTest\CodeFirstTest\DB\Test.mdf;Integrated Security=True")
        {
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
