    public async Task BroadcastConnectionAsync(IPAddress address, int port)
    {
        try
        {
            var listener = new TcpListener(address, port);
            ServerRunning = true;
            // Start Listeneting at the specified port
            listener.Start();
            displayText.AppendText("The server is running at port 8001...\n");
            while (ServerRunning)
            {
                using (var socket = await listener.AcceptSocketAsync())
                {
                    listOFClientsSocks.Add(socket);
                    listBox1.DataSource = listOFClientsSocks;
                    displayText.AppendText("\nConnected");
                    new Thread(tcpHandler)
                    {
                        Name = "tcpHandler"
                    }.Start();
                }
            }
        }
        catch (Exception ex)
        {
            displayText.AppendText("Error----" + Environment.NewLine + ex.StackTrace);
        }
    }
