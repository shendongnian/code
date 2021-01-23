    try
    {
        while (true)
      {
          scon.Listen(100);
          Socket newSocket = scon.Accept();
          var size= newSocket.ReceiveFrom(data, ref Remote);
          Console.WriteLine($"Received {size} bytes on socket {scon.LocalEndPoint}");
      }
                
    }
    catch (SocketException ex)
    {
        Console.WriteLine(ex.Message);
    }
    Console.WriteLine(scon.LocalEndPoint.ToString() + "IP {0}: ", Remote.ToString());
