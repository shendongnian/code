    from a in LoadTestSummary
    join b in LoadTestTestSummaryData 
        on a.LoadTestRunId equals b.LoadTestRunId 
    where
       	a.TargetStack == env &&
       	a.TestGuid != null &&
       	a.StartTime != null &&
      	a.LoadTestRunId != null
    group new { a, b } by a.TestGuid into g
    select new 
	{
	    TestGuid = g.Key,
	    DateCreated = g.Min(el => el.a.StartTime),
	    NumTests = g.Select(el => el.b.TestCaseId).Count(),
	    NumScenarios = g.Select(el => el.a.Id).Distinct().Count()
	};
