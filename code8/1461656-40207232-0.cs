    TfsTeamProjectCollection collection = GetServer("<server_uri>");
    string projectUri = GetProject(collection, "<project_name");
     
    var configSvc = collection.GetService<TeamSettingsConfigurationService>();
    var configs = configSvc.GetTeamConfigurationsForUser(new[] { projectUri });
     
    foreach (TeamConfiguration config in configs)
    {
        // Output some basic team info.
        Console.WriteLine("Team name: {0}", config.TeamName);
        Console.WriteLine("Team ID: {0}", config.TeamId);
        Console.WriteLine("Is default team: {0}", config.IsDefaultTeam);
         
        // Access the actual configuration settings.
        TeamSettings ts = config.TeamSettings;
         
        // Output the information on the teams iterations.
        Console.WriteLine("Product backlog: {0}", ts.BacklogIterationPath);
        Console.WriteLine("Current iteration: {0}", ts.CurrentIterationPath);
         
        Console.WriteLine("Team iteration paths:");
     
        foreach (string path in settings.IterationPaths)
            Console.WriteLine("  {0}", path);
    }
