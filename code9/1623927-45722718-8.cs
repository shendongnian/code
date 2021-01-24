    public async Task<byte[]> ConnectToCounterpart(string dataToSend)
    {
        // === Sending empty strings breaks the program ===
        if (String.IsNullOrEmpty(dataToSend))
            return null;
        // === Variables n' Stuff ===
        string counterPartIP = "127.0.0.1"; // The ip of the computer running counterpart program. (127.0.0.1 is the localhost/current computer).
        int counterPartPort = 50_000; // The port which the counterpart program listens to
        // === Getting a connection ===
        TcpClient client = new TcpClient(counterPartIP, counterPartPort); // Connect to the counterpart program
        NetworkStream nwStream = client.GetStream(); // Get the networkStream between the main and counterpart program
        nwStream.ReadTimeout = 5_000; // Give the counterpart program 5 seconds to do its thing
        // === Convert the "dataToSend" to a byte-array ===
        byte[] bytesToSend = Encoding.UTF7.GetBytes(dataToSend); // An array with the bytes of the string (UTF7 lets you keep "cpecial characters like Æ, Ø, Å, Á etc.")
        // === Send the file-bytes ===
        await nwStream.WriteAsync(bytesToSend, 0, bytesToSend.Length); // Send the file-bytes to the counterpart program
        // ==========================================
        // At this point counterpart is doing work
        // ==========================================
        byte[] returnBytes = new byte[client.ReceiveBufferSize]; // The byte-array this method returns
        try
        {
            // === Recieve the reply ===
            int numberOfBytesRecieved = await nwStream.ReadAsync(returnBytes, 0, client.ReceiveBufferSize); // Receve the checksum from the counterpart and tthe ammount of sent bytes
            // === Crop return-array to the recieved bytes ===
            Array.Resize(ref returnBytes, numberOfBytesRecieved);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Error while retrieving"); // Show error
            returnBytes = null; // Set returnbytes to null
        }
            
        // === Close and dispose stream ===
        nwStream.Close();
        nwStream.Dispose();
        // === Return the byte-array ===
        return returnBytes;
    }
