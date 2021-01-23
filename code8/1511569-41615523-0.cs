    from pr in this.context.ComputedPrSet
    where
        pr.Date.Equals(date) && pr.Scenario.Equals(scenario)
    group pr by new { pr.Date, pr.Scenario }
    into grp
    select new
    {
        grp.Key.Date,
        grp.Key.Scenario,
        TruePositiveCount = grp.Sum(x => x.Outcome == 0?x.SamplingWeight:0)
    };
