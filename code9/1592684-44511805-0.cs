     var u = new Uri("https://[account].visualstudio.com");
                    VssCredentials c = new VssCredentials(new Microsoft.VisualStudio.Services.Common.VssBasicCredential(string.Empty, "[personal access token]"));                
    var connection = new VssConnection(u, c);
                    var testClient = connection.GetClient<TestManagementHttpClient>();
                    
                    string teamProject = "scrum2015";
                    int testRunId = 286;
                    int testSuiteId = 591;
                    RunUpdateModel runmodelUpdate = new RunUpdateModel(state: "InProgress");
                    
                    TestRun testRunUpdateResult = testClient.UpdateTestRunAsync(teamProject, testRunId, runmodelUpdate).Result;
                    var results = testClient.GetTestResultsAsync(teamProject, testRunId).Result.First();
                   var testPoints= testClient.GetPointsAsync(teamProject,Int32.Parse(testRunUpdateResult.Plan.Id), testSuiteId).Result;
                    TestRun testRunUpdate = testClient.GetTestRunByIdAsync(teamProject, testRunId).Result;
                   
                    TestResultCreateModel newTestResult = new TestResultCreateModel() { TestCase=new Microsoft.TeamFoundation.TestManagement.WebApi.ShallowReference(id: results.TestCase.Id.ToString()), TestPoint = new Microsoft.TeamFoundation.TestManagement.WebApi.ShallowReference(id: testPoints.First().Id.ToString()), Outcome="Failed",State= "Completed" };
                   var updateResult= testClient.AddTestResultsToTestRunAsync(new TestResultCreateModel[] { newTestResult }, teamProject, testRunId).Result;
                    RunUpdateModel runmodelUpdate2 = new RunUpdateModel(state: "Completed");
        
                    TestRun testRunUpdateResult2 = testClient.UpdateTestRunAsync(teamProject, testRunId, runmodelUpdate2).Result;
