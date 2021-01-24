    private void timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            SendMail._SendMail("Processing A started at" + DateTime.Now.ToString());
            Logging.log.LogInput("start refund process");
        }
        catch (Exception ex)
        {
            EventLog.WriteEntry(ex.ToString(), EventLogEntryType.Error);
        }
    }
