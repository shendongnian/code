    (from submission in db.Submissions
     join status in _ctx.SubmissionStatusEvents on submission.Id equals status.SubmissionId into statusGroup
     from status in statusGroup.OrderByDescending(status => status.Created).Take(1)
     join comment in _ctx.SubmissionComments on submission.Id equals comment.SubmissionId into commentGroup
     from comment in commentGroup.OrderByDescending(comment => comment.Created).Take(1)
    ... the rest (no change)
