    TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(new Uri("url"));
    tfs.EnsureAuthenticated();
    
    IBuildServer tfsBuildServer = tfs.GetService<IBuildServer>();
    
    IBuildDefinition buildDef = tfsBuildServer.GetBuildDefinition("TeamProject", "DefinitionName");
    
     var BuildUri = buildDef.LastBuildUri;
    
     ITestManagementService testManagement = (ITestManagementService)tfs.GetService(typeof(ITestManagementService));
     ITestManagementTeamProject testManagementTeamProject = testManagement.GetTeamProject("TeamProject");
     IEnumerable<ITestRun> testRuns = testManagementTeamProject.TestRuns.ByBuild(BuildUri);
    
    
       foreach (ITestRun testRun in testRuns)
         {
           foreach (ITestCaseResult result in testRun.QueryResults())
              {
                Console.WriteLine(string.Format("TestCaseID:{0}", result.TestCaseTitle.ToString()));
                Console.WriteLine(string.Format("TestCaseOutcome:{0}", result.Outcome.ToString()));
               }
          }
