    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Sftp,
        HostName = "example.com",
        UserName = "username",
        Password = "password",
    };
    
    sessionOptions.AddRawSettings("Tunnel", "1");
    sessionOptions.AddRawSettings("TunnelHostName", "tunnel.example.com");
    sessionOptions.AddRawSettings("TunnelUserName", "username");
    sessionOptions.AddRawSettings("TunnelPasswordPlain", "password");
    
    using (Session session = new Session())
    {
        session.Open(sessionOptions);
    
        // Your code
    }
