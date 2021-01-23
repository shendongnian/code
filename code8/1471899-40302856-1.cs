    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        Task.Factory.StartNew(doWork);
        Thread.Sleep(2000);
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
    void doWork()
    {
        Thread.Sleep(1000); // Simulate work.
        throw new InvalidOperationException("TEST");
    }
