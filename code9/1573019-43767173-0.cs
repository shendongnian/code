    // Set up session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Ftp,
        HostName = "ftp.example.com",
        UserName = "username",
        Password = "password",
        // Enable FTPS in explicit mode, aka FTPES
        FtpSecure = FtpSecure.Explicit,
    };
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
        // Your code
    }
