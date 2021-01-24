    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Sftp,
        HostName = hostAddress,
        PortNumber = port,
        UserName = username,
        SshHostKeyFingerprint = "ssh-dss 2048 0b:77:8b:68:f4:45:b1:3c:87:ad:5c:be:3b:c5:72:78",
        SshPrivateKeyPath = keyPath
    };
    using (Session session = new Session())
    {
        session.FileTransferProgress += session_FileTransferProgress;
        session.Open(sessionOptions);
        var fileName = Path.GetFileName(source);
        var destinationFile = Path.Combine(destination, fileName);
        session.GetFiles(source, destinationFile).Check();
    }
