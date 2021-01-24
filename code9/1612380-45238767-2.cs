    private ManualResetEvent _waiter = new ManualResetEvent(false);
    private void OnApplicationClick(object sender, EventArgs e)
    {
        _waiter.Set();
    }
    private void WaitForClick()
    {
        _app.Application.Click += OnApplicationClick;
        _waiter.WaitOne();
        // do something after click
    }
