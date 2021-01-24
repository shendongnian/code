    // Initialize listener.
    IPAddress address = new IPAddress(new byte[] { 127, 0, 0, 1 });
    TcpClient client;
    // Bind to address and port.
    TcpListener listener = new TcpListener(address, 12345);
    // Start listener.
    listener.Start();
    // In endless cycle accepting incoming connections.
    // Actually here must be something like while(_keepWork)
    // and on some button code to make _keepWork = false to
    // stop listening.
    while (true)
    {
        client = listener.AcceptTcpClient();
        // When client connected, starting BgWorker
        // use "using" statement to automatically free objects after work.
        using (BackgroundWorker bgWorker = new BackgroundWorker())
        {
            // EventHandler.
            bgWorker.DoWork += BgWorker_DoWork;
            // Past client as argument.
            bgWorker.RunWorkerAsync(client);
        }
    }
