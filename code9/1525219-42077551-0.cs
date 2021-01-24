    var result = db.Posts
        .Select(post => new
        {
            Title = post.Title,
            Categories = post.Posts_Categories
                .Select(pc => pc.Category.Name)
                .ToList()
        })
        .ToList();
