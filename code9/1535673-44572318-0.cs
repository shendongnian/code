    // Setup session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Ftp,
        HostName = "ftp.example.com",
        UserName = "user",
        Password = "mypassword",
    };
 
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
 
        RemoteDirectoryInfo directory = session.ListDirectory("/remote/path");
 
        foreach (RemoteFileInfo fileInfo in directory.Files)
        {
            Console.WriteLine("{0} with size {1}, permissions {2} and last modification at {3}",
                fileInfo.Name, fileInfo.Length, fileInfo.FilePermissions,
                fileInfo.LastWriteTime);
        }
    }
