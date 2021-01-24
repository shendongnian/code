    private class LogMessage
    {
        public DateTime CreatedOn {get;} = DateTime.Now;
        public string Line {get;set;}
        public LogType LogType {get; set;}
    }
    private List<LogMessage> _logQueue = new List<LogMessage>();
    private void LogAddInfo(string line, LogType lt)
    {
        lock(_logQueue)
            _logQueue.Add(new LogMessage { Line = line, LogType = lt });
    }
    private void Timer1_tick(object sender, EventArgs e)
    {
        LogMessage[] messages;
        lock(_logQueue)
        {
            messages = _logQueue.ToArray();
            _logQueue.Clear();
        }
        foreach(var msg in messages)
        {
            // add to listview
        }
    }
