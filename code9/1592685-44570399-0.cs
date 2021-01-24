            try
            {
                var u = new Uri("https://{My Account}.visualstudio.com");
                VssCredentials c = new VssCredentials(new Microsoft.VisualStudio.Services.Common.VssBasicCredential(string.Empty, "PAT"));
                var connection = new VssConnection(u, c);
                var testClient = connection.GetClient<TestManagementHttpClient>();
                int testpointid = 1;
                string teamProject = "MyProjectName";
                RunCreateModel run = new RunCreateModel(name: "TestCase Name", plan: new Microsoft.TeamFoundation.TestManagement.WebApi.ShallowReference("TestPlan Id"), pointIds: new int[] { testpointid });
                TestRun testrun = testClient.CreateTestRunAsync(run, teamProject).Result;
                
                TestCaseResult caseResult = new TestCaseResult() { State = "Completed", Outcome = "passed", Id = 100000 };
                
                var testResults = testClient.UpdateTestResultsAsync(new TestCaseResult[] { caseResult }, teamProject, testrun.Id).Result;
                RunUpdateModel runmodel = new RunUpdateModel(state: "Completed");
                TestRun testRunResult = testClient.UpdateTestRunAsync(runmodel, teamProject, testrun.Id, runmodel).Result;
                
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.InnerException.Message);
            }
