    public static class parser
    {
        public static string evlLocation = "%Program Files (x86)%\\EventLogParser\\ImportedEventLogs\\" + varBank.logInput;
        public static string evlLocationManual = "K:\\Event Log\\Test\\BSN_Navigator.evt";
    
        public static void ReadEventLog()
        {
            EventLog eventLog = new EventLog(evlLocationManual);
            EventLogEntryCollection eventLogEntries = eventLog.Entries;
            int eventLogEntryCount = eventLogEntries.Count;
            for (int i = 0; i < eventLogEntries.Count; i++)
            {
                EventLogEntry entry = eventLog.Entries[i];
                //Do Some processing on the entry
            }
            LogEntries = eventLogEntries.Cast<EventLogEntry>().ToList();
        }
        public static List<EventLogEntry> LogEntries {get; private set;}
    }
