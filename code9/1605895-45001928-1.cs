    private void Log_EntryWritten(object sender, EntryWrittenEventArgs e)
    {
        string message = e.Entry.Message;
        Console.WriteLine(message);
    }
    public void MonitorVPNLogs()
    {
        EventLog log = EventLog.GetEventLogs()
            .First(o => o.Log == "Security" && o.Source=="RemoteAccess");
    
        log.EnableRaisingEvents = true;
        log.EntryWritten += Log_EntryWritten;
    }
