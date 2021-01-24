    class MyDbContext : Dbcontext
    {
        public DbSet<Blog> Blogs {get; set;}
        public DbSet<Post> Posts {get; set;}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             // Entity framework should not generate Id for Blogs:
             modelBuilder.Entity<Blog>()
                 .Property(blog => blog.Id)
                 .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
             // Entity framework should not generate Id for Posts:
             modelBuilder.Entity<Blog>()
                 .Property(blog => blog.Id)
                 .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
             ... // other fluent API
        }
