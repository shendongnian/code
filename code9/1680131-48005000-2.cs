    public static bool checkConnection(string router_IP)
    {
        Ping pinger = new Ping();
        try
        {
            return pinger.Send(router_IP).Status == IPStatus.Success;
        }
        catch
        {
            Console.WriteLine("connection fail");
            return false;
        }
    }
