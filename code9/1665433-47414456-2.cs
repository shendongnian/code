    DateTime lastThreeHours = DateTime.Now.AddHours(-3);
    EventLog securityLog = new EventLog("Security");
    var logOnAttempts = (from log in securityLog.Entries.Cast<EventLogEntry>()
        where log.EntryType==EventLogEntryType.SuccessAudit && log.TimeWritten > lastThreeHours
        orderby log.TimeGenerated descending
        select log
    ).Take(10).ToList();
