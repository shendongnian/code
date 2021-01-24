     var u = new Uri("https://[account].visualstudio.com");
     VssCredentials c = new VssCredentials(new Microsoft.VisualStudio.Services.Common.VssBasicCredential(string.Empty, "[pat]"));
     var connection = new VssConnection(u, c);
    var testClient = connection.GetClient<TestManagementHttpClient>();
     int testpointid = 158;
     string teamProject = "scrum2015";
    RunCreateModel run = new RunCreateModel(name:"APIRun7",plan:new Microsoft.TeamFoundation.TestManagement.WebApi.ShallowReference("232"),pointIds:new int[] { testpointid });
    TestRun testrun = testClient.CreateTestRunAsync(teamProject, run).Result;
    TestCaseResultUpdateModel testCaseUpdate = new TestCaseResultUpdateModel() { State="Completed", Outcome="Passed", TestResult=new Microsoft.TeamFoundation.TestManagement.WebApi.ShallowReference("100000") };
    var testResults = testClient.UpdateTestResultsAsync(new TestCaseResultUpdateModel[] { testCaseUpdate }, teamProject, testrun.Id).Result;
    RunUpdateModel runmodel = new RunUpdateModel(state: "Completed");
    TestRun testRunResult= testClient.UpdateTestRunAsync(teamProject, testrun.Id, runmodel).Result;
            
