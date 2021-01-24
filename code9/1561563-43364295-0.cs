    var allowedSuspendDaysExpiredSims = searchCriteria.UserInputSims
        .Select((s, i) => new
        {
            Obj = s,
            Ix = i,
        })
        .Where(s => obj.HasExpiredAllowedSuspendDays(s.Obj.SimId, searchCriteria.ServiceTypeId, searchCriteria.ToState.Id))
        .Select(s => new
        {
            s.Obj.SimNumber,
            s.Ix,
        }).ToList();
    if (allowedSuspendDaysExpiredSims != null)
    {
        return allowedSuspendDaysExpiredSims.Select(s =>
        new InvalidSimContract
        {
            Message = String.Format("Line {0} contains SIM Number :{1} has expired the maximum allowed suspension days for this year. Allowed suspension days for the year is {2} days.", s.Ix + 1, s.SimNumber, _allowedSuspendDaysInLast12Months),
            UserInput = s.SimNumber,
            ImeiNumber = string.Empty,
            LineNumber = s.Ix + 1
        }
        ).ToList();
    }
