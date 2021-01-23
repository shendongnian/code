	this.Context.ComputedPrSet
		.Where(pr => pr.Date == date && pr.Scenario == scenario)
		.GroupBy(pr => new { pr.Date, pr.Scenario, pr.Outcome })
		.Select(grp => new {
			grp.Key.Date,
			grp.Key.Scenario,
			grp.Key.Outcome,
			Count = grp.Sum(pr => pr.SamplingWeight)
		})
		.AsEnumerable()
		// .AsEnumerable() will "close" the query in LINQ.
		// Further operations are done via LINQ to Objects after fetching the prior results from your DB
		.GroupBy(e => new { e.Date, e.Scenario })
		.Select(g => new {
			g.Key.Date,
			g.Key.Scenario,
			TruePositiveCount = g.FirstOrDefault(e => e.Outcome == 0),
			FPCount = g.FirstOrDefault(e => e.Outcome == 1),
		});
