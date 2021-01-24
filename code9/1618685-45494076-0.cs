    AutoResetEvent waitHandle = new AutoResetEvent(false);
    System.Timer(() => waitHandle.Set(), null, TimeSpan.FromMinutes(1), TimeSpan.FromMilliseconds(-1));
    
    while (true)
    {
      // Do stuff
      waitHandle.WaitOne();
    }
