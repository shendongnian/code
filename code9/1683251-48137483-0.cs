    // Assuming your navigation property is called VoteMedia
    await _context.Votes.
        .Include(vote => vote.VoteMedia)
        ...
        .Select( vote => new
        {
            Id = vote.Id,
            VoteQuestions = vote.VoteQuestions,
            // here you reference to VoteMedia from your Model
            // EF Core recognize that and will load VoteMedia too.
            //
            // When using _context.VoteMedias.Where(...), EF won't do that
            // because you directly call into the context
            VoteImages = vote.VoteMedias.Where(m => m.VoteId == vote.Id)
                .Select(k => k.MediaUrl.ToString()),
            // Same here
            Options = vote.VoteOptions.Where(m => m.VoteId == vote.Id).Select( ques => ... );
        }
