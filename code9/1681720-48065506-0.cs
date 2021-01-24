    public static bool Ping(string host)
    {
        for (int pass = 0; pass < 3; ++pass)
        {
            try
            {
                Ping pingSender = new Ping();
                PingReply reply = pingSender.Send(host);
                if (reply.Status == IPStatus.Success)
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    
        return false;
    }
