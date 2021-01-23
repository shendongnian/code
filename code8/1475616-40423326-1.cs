    private void Form1_Load(object sender, EventArgs e)
    {
        EventLog logListener = new EventLog("Security");
        logListener.EntryWritten += logListener_EntryWritten;
        logListener.EnableRaisingEvents = true;
        this.reportViewer1.RefreshReport();
    }
    void logListener_EntryWritten(object sender, EntryWrittenEventArgs e)
    {
        //4624: An account was successfully logged on.
        //4625: An account failed to log on.
        //4648: A logon was attempted using explicit credentials.
        //4675: SIDs were filtered.
        var events = new int[] { 4624, 4625, 4648, 4675 };
        if (events.Contains(e.Entry.EventID))
            System.IO.File.AppendAllLines(@"d:\log.txt", new string[] {
                string.Format("{0}:{1}",  e.Entry.EventID, e.Entry.Message)
            });
    }
