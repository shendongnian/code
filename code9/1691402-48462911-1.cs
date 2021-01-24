    using (var context = new BloggingContext())
    {
        var blogProps = context.Blogs
            .SelectMany(b => 
                b.Posts.Select(p => 
                    new { Blog = b, PostTitle = p.Title }
                )
             )
            .ToList();
    }
