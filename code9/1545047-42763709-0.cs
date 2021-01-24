    static readonly AutoResetEvent fileCopyEvent = new AutoResetEvent(false);
    
    bool keepFileCopyThreadAlive = true;
    void FileCopyThread()
    {
    	while (keepFileCopyThreadAlive)
    	{
    		fileCopyEvent.WaitOne(); 
            if (!keepFileCopyThreadAlive) return; // Exit thread if told to.
    		Console.WriteLine("Copying files...");
    		Thread.Sleep(1000); // Do your stuff here
    		Console.WriteLine("Done copying files, waiting for USB Thread.");
    	}
    }
