    public static bool PingServer(string serverName)
    {
        try { return new Ping().Send(serverName)?.Status == IPStatus.Success; }
        catch { return false; }
    }
