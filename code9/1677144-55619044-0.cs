    var creds = new VssBasicCredential(string.Empty, "personalaccesstoken");
    VssConnection connection = new VssConnection(new Uri("url"), creds);
    var workClient = connection.GetClient<WorkHttpClient>();
    var teamContext = new TeamContext(teamId);
    teamContext.ProjectId = projectId;
    var currentIteration = await workClient.GetTeamIterationsAsync(teamContext, "current");
