    var files = new List<string>();
    foreach (DriveInfo d in DriveInfo.GetDrives().Where(x => x.IsReady == true))
    {
        var matchingFiles = Directory.GetFiles(d.RootDirectory.FullName, actualFile, SearchOption.AllDirectories));
        foreach (var matchedFile in matchingFiles)
        {
            var fileInfo = new FileInfo(matchedFile);
        
            // The newly created fileInfo will have everything you need, including path inside the FullName
            files.Add(fileInfo.FullName);
        }
    }
