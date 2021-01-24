    using (var context = new BloggingContext())
    {
        var blogs = context.Blogs
            .Include(blog => blog.Posts)
            .Include(blog => blog.Owner)
            .ToList();
    }
