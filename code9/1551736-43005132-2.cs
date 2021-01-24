    while (!cliente.Connected)
    {
        int milliseconds = 2000;
        Thread.Sleep(milliseconds);
        cliente.Connect(IP_End);
 
        if (cliente.Connected)
        {
            connectRead();
            a = 2;
        }
    }
