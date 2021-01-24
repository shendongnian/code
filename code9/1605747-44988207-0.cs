    // Setup session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Ftp,
        HostName = "example.com",
        UserName = "user",
        Password = "mypassword",
    };
    
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
    
        // Synchronize files
        session.SynchronizeDirectories(
            SynchronizationMode.Local, @"C:\local\path", "/remote/path", false).Check();
    }
