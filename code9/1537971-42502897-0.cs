    private const string dbFileName = "Chinook.sdf";
    private static void CreateIfNotExists(string fileName)
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        // Set the data directory to the users %AppData% folder            
        // So the database file will be placed in:  C:\\Users\\<Username>\\AppData\\Roaming\\            
        AppDomain.CurrentDomain.SetData("DataDirectory", path);
    
        // Enure that the database file is present
        if (!System.IO.File.Exists(System.IO.Path.Combine(path, fileName)))
        {
            //Get path to our .exe, which also has a copy of the database file
            var exePath = System.IO.Path.GetDirectoryName(
                new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath);
            //Copy the file from the .exe location to the %AppData% folder
            System.IO.File.Copy(
                System.IO.Path.Combine(exePath, fileName),
                System.IO.Path.Combine(path, fileName));
        }
    }
