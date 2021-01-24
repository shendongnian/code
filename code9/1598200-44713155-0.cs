    int testpointid = 176;
                var u = new Uri("https://[account].visualstudio.com");
                VssCredentials c = new VssCredentials(new Microsoft.VisualStudio.Services.Common.VssBasicCredential(string.Empty, "[pat]"));
                TfsTeamProjectCollection _tfs = new TfsTeamProjectCollection(u, c);
                ITestManagementService test_service = (ITestManagementService)_tfs.GetService(typeof(ITestManagementService));
                ITestManagementTeamProject _testproject = test_service.GetTeamProject("scrum2015");
                ITestPlan _plan = _testproject.TestPlans.Find(115);
                ITestRun testRun = _plan.CreateTestRun(false);
                testRun.Title = "apiTest";
                ITestPoint point = _plan.FindTestPoint(testpointid);
                testRun.AddTestPoint(point, test_service.AuthorizedIdentity);
                testRun.Save();
                testRun.Refresh();
                ITestCaseResultCollection results = testRun.QueryResults();
                ITestIterationResult iterationResult;
    
                foreach (ITestCaseResult result in results)
                {
                    iterationResult = result.CreateIteration(1);
                    foreach (Microsoft.TeamFoundation.TestManagement.Client.ITestStep testStep in result.GetTestCase().Actions)
                    {
                        ITestStepResult stepResult = iterationResult.CreateStepResult(testStep.Id);
                        stepResult.Outcome = Microsoft.TeamFoundation.TestManagement.Client.TestOutcome.Passed; //you can assign different states here
                        iterationResult.Actions.Add(stepResult);
                    }
                    iterationResult.Outcome = Microsoft.TeamFoundation.TestManagement.Client.TestOutcome.Passed;
                    result.Iterations.Add(iterationResult);
                    result.Outcome = Microsoft.TeamFoundation.TestManagement.Client.TestOutcome.Passed;
                    result.State = TestResultState.Completed;
                    result.Save(true);
                }
                testRun.State = Microsoft.TeamFoundation.TestManagement.Client.TestRunState.Completed;
                results.Save(true);
                
