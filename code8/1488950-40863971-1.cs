    public bool IsComputerUsedByTS()
    {
        var tsMgr = new TerminalServicesManager();
        var localSvr = tsMgr.GetLocalServer();
        var sessions = localSvr.GetSessions();
        foreach(var session in sessions)
        {
            if(session.ConnectionState == ConnectionState.Active || 
               session.ConnectionState == ConnectionState.Connected) //Add more states you want to check for as needed
            {
                return true;
            }
        }
        return false;
    }
