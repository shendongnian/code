    EventLog log = EventLog.GetEventLogs()
        .First(o => o.Log == "Security" && o.Source=="RemoteAccess");
    
    foreach (EventLogEntry entry in log.Entries)
    {
        Console.WriteLine("\tEntry: " + entry.Message);
    }
