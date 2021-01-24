    ManualResetEvent waitHandle = new ManualResetEvent (false);
    System.Timer(() => waitHandle.Set(), null, TimeSpan.FromMinutes(1), TimeSpan.FromMilliseconds(-1));
    
    while (true)
    {
      // Do stuff
      waitHandle.Reset();
      waitHandle.WaitOne();
    }
