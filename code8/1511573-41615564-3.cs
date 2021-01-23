    from pr in this.context.ComputedPrSet
    where
        pr.Date.Equals(date) && pr.Scenario.Equals(scenario)
    group pr by new { pr.Date, pr.Scenario }
    into grp
    select new
               {
                   grp.Key.Date,
                   grp.Key.Scenario,
                   TruePositiveCount = grp.Where(x => x.outcome == 0).Sum(x => x.SamplingWeight),
                   FPCount = grp.Sum(x => x.outcome == 1 ? x.SamplingWeight : 0),
               };
