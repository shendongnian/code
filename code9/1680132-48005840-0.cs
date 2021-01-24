    // Setup session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Ftp,
        HostName = "example.com",
        UserName = "user",
        Password = "mypassword",
        FtpSecure = FtpSecure.Explicit, // Or .Implicit
    };
    // Configure proxy
    sessionOptions.AddRawSettings("ProxyMethod", "3");
    sessionOptions.AddRawSettings("ProxyHost", "proxy");
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
        var listing = session.ListDirectory(path);
    }
