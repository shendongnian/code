    var mutex = new Mutex(false, "MyLoggingMutex");
    try
    {
        mutex.WaitOne();
        using (var stream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite, 4096, false))
        {
            var writer = new TextWriter(stream);
            writer.Write(message);
        }
    }
    finally
    {
        mutex.ReleaseMutex();        
    }
