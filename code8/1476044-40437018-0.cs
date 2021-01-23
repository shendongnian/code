    static readonly object syncObject = new object();
    void Thread1()
    {
      lock (syncObject) Monitor.Wait(syncObject);
    }
    
    void Thread2()
    {
      lock (syncObject) Monitor.Pulse(syncObject);
    }
