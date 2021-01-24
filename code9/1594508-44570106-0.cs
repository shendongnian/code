            try
            {
                var u = new Uri("https://sl00487792.visualstudio.com");
                VssCredentials c = new VssCredentials(new Microsoft.VisualStudio.Services.Common.VssBasicCredential(string.Empty, "wksbxlogubvqkyea2jkci3hn53o462sdz6pw3v4ztpw6x2sxdy5a"));
                var connection = new VssConnection(u, c);
                var testClient = connection.GetClient<TestManagementHttpClient>();
                int testpointid = 2;
                string teamProject = "TestAppl";
                RunCreateModel run = new RunCreateModel(name: "Verify HomePage", plan: new Microsoft.TeamFoundation.TestManagement.WebApi.ShallowReference("112"), pointIds: new int[] { testpointid });
                TestRun testrun = testClient.CreateTestRunAsync(run, teamProject).Result;
                
                TestCaseResult caseResult = new TestCaseResult() { State = "Completed", Outcome = "passed", Id = 100000 };
                
                var testResults = testClient.UpdateTestResultsAsync(new TestCaseResult[] { caseResult }, teamProject, testrun.Id).Result;
                RunUpdateModel runmodel = new RunUpdateModel(state: "Completed");
                TestRun testRunResult = testClient.UpdateTestRunAsync(runmodel, teamProject, testrun.Id, runmodel).Result;
                Console.WriteLine("Success");
                Console.ReadKey();
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.InnerException.Message);
                Console.ReadKey();
            }
