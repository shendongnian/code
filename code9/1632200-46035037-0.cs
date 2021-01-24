    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    namespace Sample
    {
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlCe(@"Data Source=C:\data\Blogging.sdf");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .HasMany(b => b.Posts)
                .WithOne(p => p.Blog)
                .HasForeignKey(p => p.BlogId);
        }
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
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
    }
