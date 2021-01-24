    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Sftp,
        HostName = "example.com",
        UserName = "username",
        Password = "password",
        SshHostKeyFingerprint = "ssh-rsa 2048 xxxxxxxxxxx...=",
    };
    
    sessionOptions.AddRawSettings("Tunnel", "1");
    sessionOptions.AddRawSettings("TunnelHostName", "tunnel.example.com");
    sessionOptions.AddRawSettings("TunnelUserName", "username");
    sessionOptions.AddRawSettings("TunnelPasswordPlain", "password");
    sessionOptions.AddRawSettings("TunnelHostKey", "ssh-rsa 2048 xxxxxxxxxxx...=");
    
    using (Session session = new Session())
    {
        session.Open(sessionOptions);
    
        // Your code
    }
