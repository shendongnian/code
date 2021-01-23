    Uri tfsUri = new Uri("http://servername:8080/tfs/collectionname");
    teamProjectCollection = new TfsTeamProjectCollection(tfsUri);
     
    iTestManagementService = teamProjectCollection.GetService<ITestManagementService>();
    tfsConnectedTeamProject = iTestManagementService.GetTeamProject("Team Project Name");
