    using (var context = new BloggingContext())
    {
        var blogProps = context.Blogs
            .Select(b => 
                new Blog 
                { 
                    Name = b.Name, 
                    Posts = new List<Post>(b.Posts.Select(p => 
                        new Post 
                        { 
                            Title = p.Title 
                        })
                }
            )
            .ToList();
    }
