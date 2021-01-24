    bool IsPortOpen(string host, int port, TimeSpan timeout)
    {
        try
        {
            using(var client = new TcpClient())
            {
                var result = client.BeginConnect(host, port, null, null);
                var success = result.AsyncWaitHandle.WaitOne(timeout);
                if (!success)
                {
                    return false;
                }
    
                client.EndConnect(result);
            }
    
        }
        catch
        {
            return false;
        }
        return true;
    }
