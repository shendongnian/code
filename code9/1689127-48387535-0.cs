    public static void Main()
      { 
        TcpListener server=null;   
        try
        {
          Int32 port = 58000;
          IPAddress localAddr = IPAddress.Parse("127.0.0.1");
    
          // TcpListener server = new TcpListener(port);
          server = new TcpListener(localAddr, port);
    
          // Start listening for client requests.
          server.Start();
    
          // DO ALL YOUR WORK
        }
        catch(SocketException e)
        {
          Console.WriteLine(e.ToString());
        }
        finally
        {
           // Stop listening for new clients.
           server.Stop();
        }
      }   
