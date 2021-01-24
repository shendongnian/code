    // Set up session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Ftp,
        PortNumber = port,
        HostName = "ftp.example.com",
        UserName = "ftpätest",
        Password = "sampleäpass",
    };
    
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
    
        // Your code
    }
