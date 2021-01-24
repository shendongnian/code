    using System.Threading;
    private ManualResetEvent shutdownEvent = new ManualResetEvent(false);
    // Allow external user to signal work to stop.
    public void Shutdown()
    {
        this.shutdownEvent.Set();
    }
    private void DoWork()
    {
        // This approach requires checking the event each time through the loop,
        // which involves overhead I wish to minimize.
        while (!this.shutdownEvent.WaitOne(0))
        {
            // Do some ongoing work here...
        }
    }
