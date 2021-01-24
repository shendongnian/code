    private void DisplayPinnedTaskBarElements()
    {
        //Declaring local variables
        string pinnedTaskBarItemsPath = Environment.ExpandEnvironmentVariables(@"%AppData%\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar");
        var pinnedTaskBarFiles = Directory.GetFiles(pinnedTaskBarItemsPath);
        
        foreach (var file in pinnedTaskBarFiles)
        {
            FileInfo fileInfo = new FileInfo(file);
            Console.WriteLine(fileInfo.Name);
        }
    }
