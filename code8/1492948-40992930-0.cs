    public static bool CanBePinged(string hostname)
    {
        if (string.IsNullOrWhiteSpace(hostname)) throw new ArgumentException("hostname");
        Ping p1 = new Ping();
        try
        {
            PingReply PR = p1.Send(hostname);
            return PR.Status == IPStatus.Success;
        }catch(Exception e)
        {
            return false;
        }
    }
