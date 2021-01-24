    var toTake = 10; var maxCommentId = 10;
    IEnumerable<Comment> comments = (from a in context.Comments
        where a.ArticleID == ArticleID
        && a.CommentID > maxCommentId // <- new filter here
        orderby a.CommentDate descending
        select new Comment
        {
            CommentID = a.CommentID,
            CommentContent = a.CommentContent,
            CommentDate = a.CommentDate
        })
        .Take(toTake).ToList();
