    public bool InsertPolls(PollModel _polls)
    {       
        polls = new Poll();
        polls.Name = _polls.name;
        polls.startDate = startDate;
        polls.endDate = endDate;
        polls.Type = _polls.pollType;
        foreach (var candidatesID in _polls.candidateID)
        {
            candidates = new candidate();
            candidates.Person_ID = candidatesID;
            candidates.Poll = polls;
            _dbContext.candidates.Add(candidates);
            _dbContext.SaveChanges();
        }
    }
