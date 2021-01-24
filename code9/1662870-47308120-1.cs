	public class PostConfiguration : IEntityTypeConfiguration<Post>
	{
		public void Configure(EntityTypeBuilder<Post> builder)
		{
			builder.HasOne(y => y.Blog)
					.WithMany(x => x.Posts)
					.HasForeignKey(x => x.BlogForeignKey);
		}
	}
    public class ApplicationContext :DbContext
    {
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.ApplyConfiguration(new PostConfiguration());
		}
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Post> Posts { get; set; }
	}
	public class Blog
	{
		public int BlogId { get; set; }
		public string Url { get; set; }
		public List<Post> Posts { get; set; }
	}
	public class Post
	{
		public int PostId { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public int BlogForeignKey { get; set; }
		public Blog Blog { get; set; }
	}
