    public IFileProvider GetFileProvider()
    {
    	var drives = DriveInfo.GetDrives();
    	List<IFileProvider> fileProviders = new List<IFileProvider>();
    	foreach(var drive in drives)
    	{
   			if (drive.IsReady)
   			{
   				fileProviders.Add(new PhysicalFileProvider(drive.RootDirectory.ToString()));
   			}
    	}
    	return new CompositeFileProvider(fileProviders.ToArray());
    }
