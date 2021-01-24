    private void RefreshTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine($"RefreshTimer ManagedThreadID: {Thread.CurrentThread.ManagedThreadId}");
        Application.Current.Dispatcher.Invoke(new Action(() => { TestMethod(); }))
    }
