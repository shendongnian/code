               var nightlyRuns = (from a in LoadTestSummaries
                join b in LoadTestTestSummaryData
                on a.LoadTestRunId equals b.LoadTestRunId
                where a.TargetStack == "LoadEnv" &&
                a.TestGuid != null &&
                a.StartTime != null &&
                a.LoadTestRunId != null
				into testGroup
				
				select new 
                {
                    TestGuid = a.TestGuid,
                    ScenarioRun = new 
                    {
                        Name = a.TestGuid,
                        Description = a.Description,
                        StartTime = a.StartTime ?? a.DateCreated,
                        Duration = a.Duration,
                        NumAgents = g.Key.NumAgents,
                        NumHosts = a.NumHosts,
                        Result = a.PassFail,
                        ResultsFilePath = a.ResultsFilePath,
                        SplunkLink = a.Splunk,
                        // PROBLEM: Causes too many queries:
                        TestRuns =testGroup
                    }
                }).OrderBy(x=>x.StartTime).ToLookup(x => x.TestGuid, x => x.ScenarioRun);
				
				nightlyRuns["ba593f66-695f-4fd1-99c3-71253a2e4981"].Dump();
				
