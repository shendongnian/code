    //Your combobox string
    Version loSelectedVersion = new Version("5.9.4");
    
    Dictionary<Version, string> loVersionFiles = new Dictionary<Version, string>();
    foreach (var lsFilename in Directory.GetFiles(@"E:\Temp\Version"))
    {
        var loMatch = Regex.Match(lsFilename, @"(?<version>\d+.\d+.\d+.\d+)");
        if (loMatch.Success)
            loVersionFiles.Add(new Version(loMatch.Value), lsFilename);
    }
    
    //Excact match with your selectedVersion
    var loEntry = loVersionFiles
        .OrderByDescending(item => item.Key)
        .FirstOrDefault(item => string.Format("{0}.{1}.{2}", item.Key.Major, item.Key.Minor, item.Key.Build) == loSelectedVersion.ToString());
    
    if (loEntry.Key != null)
    {
        Console.WriteLine(loEntry.Value);
    }
    else
    {
        //Version Not Found -> look for the nearest
        loEntry = loVersionFiles
            .OrderByDescending(item => item.Key)
            .FirstOrDefault(item => item.Key < loSelectedVersion);
        if (loEntry.Key != null)
        {
            Console.WriteLine(loEntry.Value);
        }
    }
