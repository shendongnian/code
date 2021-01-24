    ActionBlock<string> _mailerBlock;
   
    public void Init()
    {
        var options=new ExecutionDataflowBlockOptions { 
            MaxDegreeOfParallelism = 5
         };
        _mailerBlock = new ActionBlock<string>(path=>xlmRead(path),options);
    }
    public void OnChanged(object sender, FileSystemEventArgs e)
    {
        _logger.Info("File Added " + e.FullPath);
        _mailerBlock.Post(e.FullPath);
    } 
