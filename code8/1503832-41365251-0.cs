    string _LogFile = String.Concat(@"C:\TEMP\SQLCLR_", Guid.NewGuid(), ".log");
    File.AppendAllText(_LogFile, @"Starting operation for: " + sourceFolder +
                                  @" --> " + destinationFolder);
    if (Directory.Exists(destinationFolder))
    {
        File.AppendAllText(_LogFile, @"Deleting: " + destinationFolder);
        Directory.Delete(destinationFolder, true);
    }
    
    if (Directory.Exists(sourceFolder))
    {
        if (!Directory.Exists(destinationFolder))
        {
            File.AppendAllText(_LogFile, @"Moving: " + sourceFolder);
            Directory.Move(sourceFolder, destinationFolder);
        }
        else
        {
            File.AppendAllText(_LogFile, @"Oops. " + destinationFolder +
                                         @" already exists. How odd indeed!");
        }
    }
