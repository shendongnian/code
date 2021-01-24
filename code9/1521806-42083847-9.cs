    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Sftp,
        HostName = "example.com",
        UserName = "username",
        Password = "password",
        SshHostKeyFingerprint = "ssh-dss ...",
    };
    using (Session session = new Session())
    {
        session.Open(sessionOptions);
        string ftpDirectory = "/dv/inbound/"; 
        string localDirectory = @"E:\Zatpark upload\*.xml";
        session.PutFiles(localDirectory, ftpDirectory).Check();
    }
