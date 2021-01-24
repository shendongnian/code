    var teamDriveList = service.Teamdrives.List();
        
    teamDriveList.Fields = "teamDrives(kind, id, name)";
    var teamDrives = teamDriveList.Execute().TeamDrives;
    if (teamDrives != null && teamDrives.Count > 0)
    {
        foreach (var drive in teamDrives)
        {
            Console.WriteLine("{0} ({1})", drive.Name, drive.Id);
        }
    }
