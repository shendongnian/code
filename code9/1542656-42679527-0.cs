    string ispacFile = @"C:\Temp\ssis_project.ispac";
    Project prj = Project.OpenProject(ispacFile);
    foreach(ConnectionManagerItem conn in prj.ConnectionManagerItems)
    {
        Console.WriteLine(conn.StreamName);
        // other operations as needed
    }
