    string logDate = DateTime.Now.ToString("yyyy-MM-dd");
    try
    {
        Windows.ApplicationModel.Package package = Windows.ApplicationModel.Package.Current;
        string appName = package.DisplayName;
        LOG_FILENAME = appName + "_" + logDate + ".log";
    }
    catch
    {
        // defaultname you defined somewhere else
        LOG_FILENAME += "_" + logDate + ".log";
    }
    
    StorageFolder folder = ApplicationData.Current.LocalFolder;
                
    logFile = await folder.CreateFileAsync(LOG_FILENAME, CreationCollisionOption.OpenIfExists);
