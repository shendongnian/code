    // Setup session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Ftp,
        HostName = "ftp.example.com",
        UserName = "username",
        Password = "password",
    };
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
        // Download files created in 2017-06-15 and later
        TransferOptions transferOptions = new TransferOptions();
        transferOptions.FileMask = "*>=2017-06-15";
        session.GetFiles("/remote/path/*", @"C:\local\path\", false, transferOptions).Check();
    }
