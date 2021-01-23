    readonly UserActivityMonitor _monitor = new UserActivityMonitor();
    protected override async void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        await _monitor.WaitForInactivity(TimeSpan.FromMinutes(10), TimeSpan.FromSeconds(5), CancellationToken.None);
        this.Close();
    }
