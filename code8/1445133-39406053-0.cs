    [HttpPost]
    public ActionResult Create(CommentsViewModel comments)//, int ArticleId)
    {
        var comment = new Comments
        {
            Comment = Server.HtmlEncode(comments.Comment),
            ArticleId = comments.Articles.ArticleId,  // Since you are using model.Articles.ArticleId in view
            CommentByUserId = User.Identity.GetUserId()
        };
    }
