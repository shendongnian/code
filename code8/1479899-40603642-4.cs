    List<LogEntry> loggbok = new List<LogEntry>();
    for (int i = 0; i < 5; i++)
    {
        LogEntry entry = new LogEntry();
        entry.Date = DateTime.Now;
        entry.Title = "title" + i;
        entry.Post = "post" + i;
        loggbok.Add(entry);
    }
