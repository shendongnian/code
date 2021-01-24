    host = Dns.GetHostEntry("localhost");                
    for (int i = 0; i <= host.AddressList.Length - 1; i++)
    {
      if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork) // check if family is IPv4 
      {
        localAddress = host.AddressList[i];
        // init Listener
        listener = new TcpListener(localAddress, port);
        // start Listener 
        listener.Start();
        // ..
      }
    }
