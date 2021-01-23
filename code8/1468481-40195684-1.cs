    public bool InsertPolls(PollModel _polls)
    {       
        polls = new Poll();
        polls.Name = _polls.name;
        polls.startDate = startDate;
        polls.endDate = endDate;
        polls.Type = _polls.pollType;
        _dbContext.Polls.Add(polls);
        _dbContext.SaveChanges();
        foreach (var candidatesID in _polls.candidateID)
        {
            candidates = new candidate();
            candidates.Person_ID = candidatesID;
            _dbContext.candidates.Add(candidates);
            _dbContext.SaveChanges();
        }
    }
