    // Setup session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Ftp,
        HostName = "example.com",
        UserName = "user",
        Password = "mypassword",
    };
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
 
        RemoteDirectoryInfo directory = session.ListDirectory("/home/martin/public_html");
 
        foreach (RemoteFileInfo fileInfo in directory.Files)
        {
            if (fileInfo.IsDirectory)
            {
                // directory
            }
            else
            {
                // file
            }
        }
    }
 
