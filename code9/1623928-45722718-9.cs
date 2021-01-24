    private void BackgroundWorkerCalculate_Counterpart_DoWork(object sender, DoWorkEventArgs e)
    {
        // === Variables n' Stuff ===
        int listeningPort = 50_000; // The port which the counterpart program listens to
        // === Start listening ===
        TcpListener listener = new TcpListener(IPAddress.Any, listeningPort); // Listen to the port
        listener.Start();
        // Infinite loop for infinite computations
        while (true)
        {
            // === Getting a connection ===
            TcpClient connection = listener.AcceptTcpClient();
            NetworkStream nwStream = connection.GetStream();
            // === Get the recieved bytes ===
            byte[] recievedBytes = new byte[connection.ReceiveBufferSize]; // Create a buffer for the incomming file-bytes
            int numberOfBytesRecieved = nwStream.Read(recievedBytes, 0, connection.ReceiveBufferSize); // Read the bytes to the buffer
            // === Convert recieved bytes to a string ===
            string recievedString = Encoding.UTF7.GetString(recievedBytes, 0, numberOfBytesRecieved);
            // ====================================================================================
            // The string "recievedString" is now the piece of text you sent to the counterpart.
            // Do with it what you want
            // ====================================================================================
            // === Create a reply to the main program ===
            string replyString = "Reply"; // This string is the data you want the main program to recieve
            byte[] replyBytes = Encoding.UTF7.GetBytes(replyString); // These are the bytes to send back
            // === Send the reply ===
            nwStream.Write(replyBytes, 0, replyBytes.Length);
        }
    }
