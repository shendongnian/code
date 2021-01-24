    using (EventLog eventLog = new EventLog("Application"))
    {
        eventLog.Source = "Application";
        foreach (EventLogEntry entry in eventLog.Entries)
        {
            DateTime errorTime = entry.TimeGenerated;
        }
    }
