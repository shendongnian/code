    string projectFolder = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
    string folderAppData = Path.Combine(projectFolder, "App_Data");
    if (Directory.Exists(folderAppData))
    {
        foreach (string file in Directory.EnumerateFiles(folderAppData,"*.xml"))
        {
               // Do your stuff here
        }
    }
