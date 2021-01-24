    public bool HasHistory(Guid id)
    {
        var result = GetHistory(id)
            .Aggregate(new { stateIsZero = true, stateIsPositive = true, hasItems = false },
            (a, x) => new
            {
                stateIsZero = a.stateIsZero && x.State == 0,
                stateIsPositive = a.stateIsPositive && x.State > 0,
                hasItems = true
            });
        return result.stateIsZero && result.stateIsPositive && result.hasItems;
    }
