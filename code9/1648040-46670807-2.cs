    public void OnChanged(object sender, FileSystemEventArgs e)
    {
        _logger.Info("File Added " + e.FullPath);
        Task.Run(()=>xmlRead(e.FullPath));
    }
