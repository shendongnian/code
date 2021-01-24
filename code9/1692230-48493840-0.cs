    public void YourMethod
    {
      foreach (IPAddress x in ips)
      {
        if(IsServerListening(x.ToString(), 2000))
        {
          //If you can connect, then exit the foreach loop (I assume you´ll do something else)
          break;
        }
      }
    }
    
    private bool IsServerListening(string server, int port)
    {
        using(TcpClient client = new TcpClient())
        {
            try
            {
                client.Connect(server, port);
            }
            catch(SocketException)
            {
                return false;
            }
            client.Close();
            return true;
        }
    }
