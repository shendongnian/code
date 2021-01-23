    using (var clientSocket = new TcpClient())
    {
        //Connect async and wait for connection up to our timeout
        if (!clientSocket.ConnectAsync(hostIP, portNumber).Wait(TimeSpan.FromSeconds(5)))
        {
            throw new Exception("Connection timed out.");
        }
    }
