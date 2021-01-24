    var categoriesByCommentCount = query
        .Select(c => new
        {
            c.CategoryId,
            c.CategoryName, 
            CommentCount = c.Articles.SelectMany(r => r.Comments).Count()
        })
        .OrderByDescending(c => c.CommentCount)
        .ToList();
