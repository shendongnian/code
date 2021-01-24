    public async IActionResult GetComments(int articleID,
      int toSkip = 0,
      int toTake = 10)
        {
            IEnumerable<Comment> comments = (from a in context.Comments
              where a.ArticleID == articleID
              orderby a.CommentDate descending
              select new Comment
              {
                  CommentID = a.CommentID,
                  CommentContent = a.CommentContent,
                  CommentDate = a.CommentDate
              })
              .Skip(toSkip).Take(toTake).ToList();
            return comments;
        }
