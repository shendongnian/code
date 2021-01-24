    public class BlogContext : DbContext
    {
        public BlogContext()
            : base( "name=BlogContext" )
        {
        }
        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            base.OnModelCreating( modelBuilder );
            var blog = modelBuilder.Entity<T_Blog>();
            blog.HasKey( e => e.Id );
            blog.HasOptional( e => e.FeaturedPost )
                .WithMany()
                .HasForeignKey( e => e.FeaturedPostId )
                .WillCascadeOnDelete( false );
            var post = modelBuilder.Entity<T_Post>();
            post.HasKey( e => e.Id );
            post.HasRequired( e => e.Blog )
                .WithMany( e => e.Posts )
                .HasForeignKey( e => e.BlogId )
                .WillCascadeOnDelete( true );
        }
        public virtual DbSet<T_Blog> Blogs { get; set; }
        public virtual DbSet<T_Post> Posts { get; set; }
    }
    public class T_Blog
    {
        public int Id { get; set; }
        public virtual ICollection<T_Post> Posts { get; set; }
        public int? FeaturedPostId { get; set; }
        public virtual T_Post FeaturedPost { get; set; }
    }
    public class T_Post
    {
        public int Id { get; set; }
        public int? BlogId { get; set; }
        public virtual T_Blog Blog { get; set; }
    }
