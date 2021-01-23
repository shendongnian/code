    public IEnumerable<CommentWithUserDetails> GetAllPostComments(int postId)
    {
        var commentsWithUserDetails = _context.Comments.Join(_context.Users,
            c => c.UserId,
            u => u.Id,
            (comment, user) => new { User = user, Comment = comment})
            .AsEnumerable()
            .Select(i=>_modelFactory.Create(i.Comment, i.User))
            ;
        return commentsWithUserDetails;
    }
