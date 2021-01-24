    // Setup session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Ftp,
        HostName = "ftp.example.com",
        UserName = "user",
        Password = "mypassword",
    };
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
        // List files
        IEnumerable<string> list =
            session.EnumerateRemoteFiles("/", null, EnumerationOptions.AllDirectories).
            Select(fileInfo => fileInfo.FullName);
    }
