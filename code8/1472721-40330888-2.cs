    void SynchronizeLocalAndFtpDirectory(string localPath, string remotePath, SessionOptions sessionOptions)
    {
        using (Session session = new Session())
        {
            session.Open(sessionOptions);
            session.SynchronizeDirectories(
                SynchronizationMode.Remote, localPath, remotePath, false).Check();
        }
    }
