    string router_IP = "192.168.0.2";
    public static bool checkConnection()
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
