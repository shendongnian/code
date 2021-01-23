    protected override void OnClosing(CancelEventArgs e)
    {
        Dispatcher.InvokeShutdown();
        base.OnClosing(e);
    }
