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
            TcpClient connection = listener.AcceptTcpClient(); // Wait till someone tries to connect
            NetworkStream nwStream = connection.GetStream(); // Get the connection between "counterpart" and "main program"
            // === Get the buffer ===
            byte[] buffer = new byte[connection.ReceiveBufferSize]; // Create a buffer for the incomming file-bytes
            int recievedBytes = nwStream.Read(buffer, 0, connection.ReceiveBufferSize); // Read the bytes to the buffer
            Array.Resize(ref buffer, recievedBytes); // Crop to the recieved content
            // === Make the buffer readable for checksum calculation ===
            MemoryStream ms = new MemoryStream(buffer); // Create a memorystream containing the file-bytes
            try
            {
                // === Compute The checksum ===
                /*I'm not that knowlageable about checksums and hashes so i just 
                  used a simple "hashing protocol?" I found by googleing. 
                  If you have another way that does not 
                  return a byte-array, then do tell*/
                using (var md5 = MD5.Create())
                {
                    buffer = md5.ComputeHash(ms); // Get the hashcode / checksum for the file
                }
            }
            catch // In case data is corrupted
            { buffer = new byte[] { 0 }; }
            // === Send the checksum ===
            nwStream.Write(buffer, 0, buffer.Length);
            // Not closing and disposing streams here because stopping the connection could interrupt data transfer
            // Streams and connections are reset in the next itteration in any case
        }
    }
