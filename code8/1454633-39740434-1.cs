    string teamProjectName = "TeamProjectName";
    TfsTeamProjectCollection tfsCollection = new TfsTeamProjectCollection(new Uri("http://serverName:8080/tfs/MyCollection"));
     ITestManagementService testService = tfsCollection.GetService<ITestManagementService>();
    ITestManagementTeamProject teamProject = testService.GetTeamProject(teamProjectName);
    //get test point of a test case
    ITestPlan tplan = teamProject.TestPlans.Find(testplanid);
    ITestPoint point = tplan.QueryTestPoints("SELECT * FROM TestPoint WHERE TestCaseID = Testcaseid").FirstOrDefault();
                
    IIdentityManagementService ims = tfsCollection.GetService<IIdentityManagementService>();
    TeamFoundationIdentity tester = ims.ReadIdentity(IdentitySearchFactor.DisplayName, "Mike", MembershipQuery.Direct, ReadIdentityOptions.None);
    //change tester for testcase
    point.AssignedTo = tester;
    point.Save();
