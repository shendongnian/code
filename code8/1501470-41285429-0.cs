    (from submission in _ctx.Submissions
     where submission.SubmitterId == userId
     select new SubmissionWithLastEventChangeDto
     {
         Id = submission.Id,
         Title = submission.Ttile,
         Status = submission.SubmissionStatusEvents.OrderByDescending(e => e.Created).First().ToStatus,
         StatusId = submission.SubmissionStatusEvents.OrderByDescending(e => e.Created).First().ToStatusId,
         StatusChange = submission.SubmissionStatusEvents.OrderByDescending(e => e.Created).First().Status,,
         ProjectId = submission.Project.ProjectId,
         ProjectName = submission.Project.Name,
         ProjectType = submission.Project.Type,
         MaxPayout = submission.Project.ExceptionalPayout ?? submission.Project.CriticalPayout,
         LogoId = submission.Project.Company.LogoId,
         LastComment = new LastEventChangeDto(submission.SubmissionComments.OrderByDescending(e => e.Created).First())
         
     }).ToListAsync();
     
     //CTOR for this class
     public  LastEventChangeDto(SubmissionComment comment)
     {
              UserName = comment.User.UserName,
             AvatarId = comment.User.AvatarId,
             Created = comment.Created,
             Type = comment.Type,
             Content = comment.Type == EntityEnum.SubmissionCommentType.Event ? comment.Content : null
    }
