    TcpListener listener = new TcpListener(IPAddress.Any, 12345);
    listener.Start();
    while (true)
    {
        var client = listener.AcceptTcpClient();
        Task.Factory.StartNew(() =>
        {
            //Create a new file for every connection
            using (var file = File.Create(Guid.NewGuid() + ".dat"))
            {
                client.GetStream().CopyTo(file);
            }
        }, TaskCreationOptions.LongRunning);
    }
