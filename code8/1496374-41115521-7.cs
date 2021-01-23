    // Setup session options
    var sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Ftp,
        HostName = "ftp.example.com",
        UserName = "user",
        Password = "mypassword",
    };
    using (var session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
        // Enumerate files
        var options =
            EnumerationOptions.EnumerateDirectories | EnumerationOptions.AllDirectories;
        IEnumerable<RemoteFileInfo> fileInfos =
            session.EnumerateRemoteFiles("/directory/to/list", null, options);
        foreach (var fileInfo in fileInfos)
        {
            Console.WriteLine(fileInfo.FullName);
        }
    }
