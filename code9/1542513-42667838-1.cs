    private string GetWindowsHostName(string ipAddress)
    {
        try
        {
            IPHostEntry entry = Dns.GetHostEntry(ipAddress);
            if (entry != null)
            {
                try
                {
                    using (TcpClient tcpClient = new TcpClient())
                    {
                        // 445 is default TCP SMB port
                        tcpClient.Connect(ipAddress, 445);
                    }
                    using (TcpClient tcpClient = new TcpClient())
                    {
                        // 139 is default TCP NetBIOS port.
                        tcpClient.Connect(ipAddress, 139);
                    }
                    return entry.HostName;
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }
        catch (SocketException ex)
        {
            System.Console.WriteLine(ex.Message + " - " + ipAddress);
        }
        return null;
    }
