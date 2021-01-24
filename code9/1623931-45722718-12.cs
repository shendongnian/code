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
            // === Understanding the recieved data ===
            /* Lets say recievedString == "[path]" */
            byte[] replyBytes = new byte[] { 1 }; // Bytes to reply to the main program
            try
            {
                using (MD5 md5 = MD5.Create()) // Create the hashing protocol
                {
                    using (FileStream fileStream = new FileStream(recievedString, FileMode.Open)) // Open the file to hash
                    {
                        replyBytes = md5.ComputeHash(fileStream); // replyBytes now contains the hash
                    }
                }
            }
            catch
            { } // If file doesn't exist, then replyBytes stays as { 1 }, which will be returned if things goes wrong
            // === Send the reply to main program ===
            nwStream.Write(replyBytes, 0, replyBytes.Length);
        }
    }
