    ManagementEventWatcher startWatcher;
    ManagementEventWatcher stopWatcher;
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        startWatcher = new ManagementEventWatcher("Select * From Win32_ProcessStartTrace");
        startWatcher.EventArrived += new EventArrivedEventHandler(startWatcher_EventArrived);
        stopWatcher = new ManagementEventWatcher("Select * From Win32_ProcessStopTrace");
        stopWatcher.EventArrived += new EventArrivedEventHandler(stopWatcher_EventArrived);
        startWatcher.Start();
        stopWatcher.Start();
    }
    void startWatcher_EventArrived(object sender, EventArrivedEventArgs e)
    {
        MessageBox.Show(string.Format("{0} started", (string)e.NewEvent["ProcessName"]));
    }
    void stopWatcher_EventArrived(object sender, EventArrivedEventArgs e)
    {
        MessageBox.Show(string.Format("{0} stopped", (string)e.NewEvent["ProcessName"]));
    }
    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        startWatcher.Stop();
        stopWatcher.Stop();
        startWatcher.Dispose();
        stopWatcher.Dispose();
        base.OnFormClosed(e);
    }
