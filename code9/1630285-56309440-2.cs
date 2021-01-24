    using System.Threading;
    private ManualResetEvent shutdownEvent = new ManualResetEvent(false);
    // Allow external user to signal work to stop.
    public void Shutdown()
    {
        this.shutdownEvent.Set();
    }
    private void DoWork()
    {
        var sw = Stopwatch.StartNew();
        while (true)
        {
           // Do some ongoing work here...
           // Check the ShutdownEvent every second.
           if (sw.ElapsedMilliseconds >= 1000)
           {
               if (this.shutdownEvent.WaitOne(0)) { break; }
               sw.Restart();
           }
        }
    }
