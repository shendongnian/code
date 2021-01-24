    List<string> FilesList = new List<string>();
    List<string> SubDirectoriesList = new List<string>();
    DirectoryInfo di = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
    //GETS SUBDIRECTORIES FROM SELECTED PATH
    DirectoryInfo[] subdirectories = di.GetDirectories();
    for (int i = 0; subdirectories.Length >= 0; i++)
    {
        if (i > subdirectories.Length - 1)
        {
            break;
        }
        //ADD SUBDIRECTORIES TO LIST
        SubDirectoriesList.Add(subdirectories[i].FullName);
    }
    //GETS FILES FROM SUBDIRECTORIES IN LIST
    //Loop all sub directory files
    foreach (var fileItem in SubDirectoriesList)
    {
        string[] directoryFiles =  Directory.GetFiles(fileItem);
        for (int i = 0; directoryFiles.Length >= 0; i++)
        {
            if (i > directoryFiles.Length - 1)
            {
                break;
            }
            //ADD FILES TO FILES LIST
            FilesList.Add(directoryFiles[i]);
        }
    }
