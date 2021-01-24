    public static void GetDirectories(string path, Action<string> foundDirectory)
    {
        string[] dirs;
        try
        {
            dirs = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
        }
        catch (UnauthorizedAccessException)
        {
            //Ignore a directory if an unauthorized access occured
            return;
        }
    
        foreach (string dir in dirs)
        {
            foundDirectory(dir);
            //Recursive call to get all subdirectories
            GetDirectories(dir, foundDirectory);
        }
    }
