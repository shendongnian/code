    // Setup session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Ftp,
        HostName = "example.com",
        UserName = "user",
        Password = "mypassword",
    };
    // Configure proxy
    sessionOptions.AddRawSettings("ProxyMethod", "2");
    sessionOptions.AddRawSettings("ProxyHost", "proxy");
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
        // Your code
    }
