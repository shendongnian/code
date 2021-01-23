    ManagementEventWatcher watcher;
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        watcher = new ManagementEventWatcher("Select * From Win32_ProcessStopTrace");
        watcher.EventArrived += new EventArrivedEventHandler(watcher_EventArrived);
        watcher.Start();
    }
    void watcher_EventArrived(object sender, EventArrivedEventArgs e)
    {
        if ((string)e.NewEvent["ProcessName"] == "notepad.exe")
            MessageBox.Show("Notepad closed");
    }
    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        watcher.Stop();
        watcher.Dispose();
        base.OnFormClosed(e);
    }
