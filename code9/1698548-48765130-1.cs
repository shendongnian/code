    using (var context = new BloggingContext())
    {
        var blog = context.Blogs
            .Single(b => b.BlogId == 1);
        context.Entry(blog)
            .Collection(b => b.Posts)
            .Load();
    }
