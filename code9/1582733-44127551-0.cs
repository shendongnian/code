    IQueryable<VotingRecord> votingRecords = ...
    votingRecords.GroupBy(votingRecord => votingRecord.President)
    .Select(presidentGroup => new
    {
        President = presidentGroup.Key,
        VoteCount = presidentGroup.Count(),
    });
