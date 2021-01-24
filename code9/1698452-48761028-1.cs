    db.Threads.Select(x => new
    {
        x,
        User = new { Username = x.User.Username, Email = x.User.Email },
        Comments = x.Comments.Select(c => new
        {
            c.Message,
            c.CommentId,
            User = new { Username = c.User.Username, Email = c.User.Email }
        })
    });
