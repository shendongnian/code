    var workClient = connection.GetClient<WorkHttpClient>();
    var iterations = workClient.GetTeamIterationsAsync(new TeamContext("project-name")).Result;
    
    var currentDate = DateTime.Now.Date;
    var currentIterationPath = iterations
        .Select(i => new { i.Path, i.Attributes })
        .FirstOrDefault(i => currentDate >= i.Attributes.StartDate &&
                             currentDate <= i.Attributes.FinishDate)
        ?.Path;
