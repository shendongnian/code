    var toSkip = 0; var toTake = 10;
    IEnumerable<Comment> comments = (from a in context.Comments
        where a.ArticleID == ArticleID
        orderby a.CommentDate descending
        select new Comment
        {
            CommentID = a.CommentID,
            CommentContent = a.CommentContent,
            CommentDate = a.CommentDate
        })
        .Skip(toSkip).Take(toTake).ToList();
