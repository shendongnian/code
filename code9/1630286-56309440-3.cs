    using System.Threading;
    private ManualResetEvent shutdownEvent = new ManualResetEvent(false);
    // Allow external user to signal work to stop.
    public void Shutdown()
    {
        this.shutdownEvent.Set();
    }
    private void DoWork()
    {
        var et = new EasyTimer(1000);
        while (true)
        {
           // Do some ongoing work here...
           // Check the ShutdownEvent every second (or so).
           if (et.HasElapsed && this.shutdown.WaitOne(0)) { break; }
        }
        // or alternatively...
        // while (!(et.HasElapsed && this.shutdownEvent.WaitOne(0))
        // {
        //     // Do some ongoing work here...
        // }
    }
