    // Bind ip and port
    TcpListener listener = new TcpListener(new IPAddress(new byte[] { 127, 0, 0, 1 }), 12345);
    // start listener
    listener.Start();
    // endless cycle
    while (true)
    {
        // acept client
        TcpClient client = listener.AcceptTcpClient();
        // using bgworker instead of thread, i like it more :D
        using (BackgroundWorker bw = new BackgroundWorker())
        {
            // sign for dowork
            bw.DoWork += Bw_DoWork;
            // run worker and passing TcpClient as argument
            bw.RunWorkerAsync(client);
        }
    }
