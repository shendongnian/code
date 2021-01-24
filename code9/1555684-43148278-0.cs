    protected void OnTime()
    {
        while (true)
        {
            try
            {
                EventLog.WriteEntry("Dentro do WHILE foi executado!");
                _updater.Do(Connection, _usuarioConnector, _generoConnector, _bandaConnector, _musicaConnector);
                EventLog.WriteEntry("Fim do while");
            }
            catch (Exception ex)
            {
                this.EventLog.WriteEntry("ERROR: " + ex.GetType().ToString() + " : " + ex.Message + " : " + ex.StackTrace, EventLogEntryType.Error);
            }
    
            Thread.Sleep(Interval);
        }
    }
