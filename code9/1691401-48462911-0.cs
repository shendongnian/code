    using (var context = new BloggingContext())
    {
        var blogProps = context.Blogs
            .SelectMany(b => 
                b.Posts.Select(p => 
                    new { PostTitle = p.Title, Content = p.Content }
                )
             )
            .ToList();
    }
