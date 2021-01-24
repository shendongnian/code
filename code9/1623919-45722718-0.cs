    private async void ButtonCalculate_Counterpart_Click(object sender, EventArgs e)
    {
        /*First we'll send the file to the counterpart*/
        // === Variables n' Stuff ===
        string counterPartIP = "127.0.0.1"; // The ip of the computer running counterpart program. (127.0.0.1 is the localhost/current computer).
        int counterPartPort = 50_000; // The port which the counterpart program listens to
            
        // === Finding a file ===
        openFileDialog1.ShowDialog(); // Find the file you want "calculated"
            
        // === Getting a connection ===
        TcpClient client = new TcpClient(counterPartIP, counterPartPort); // Connect to the counterpart program
        NetworkStream nwStream = client.GetStream(); // Get the networkStream between the main and counterpart program
        nwStream.ReadTimeout = 5_000; // Give the counterpart program 5 seconds to do its thing
        // === Get the file-bytes / filestream ===
        var stream = File.OpenRead(openFileDialog1.FileName); // The stream of bytes from the file "X"
        MemoryStream ms = new MemoryStream(); // Create a memorystream
        stream.CopyTo(ms); // Copy the filestream to the memory stream
        byte[] buffer = ms.ToArray(); // A buffer with the bytes of the file
        // === Send the file-bytes ===
        await nwStream.WriteAsync(buffer, 0, buffer.Length); // Send the file-bytes to the counterpart program
        // ================================================================
        // Goto counterpart code to see what happens in between here
        // ================================================================
        /*And now we will get the checksum, which was calculated by the counterpart*/
        // === Recieve the checksum ===
        try // if anything should fail when getting the checksum, then skip
        {
            byte[] checksum = new byte[client.ReceiveBufferSize]; // Set "checksum" to a new byte-array with the size of the maximum ammount of bytes recieved
            int recievedBytes = await nwStream.ReadAsync(checksum, 0, client.ReceiveBufferSize); // Receve the checksum from the counterpart and tthe ammount of sent bytes
                
            Array.Resize(ref checksum, recievedBytes); // Crop to the recieved content
                
            // ========================================================================
            // At this point the byte-array "checksum" is your checksum in byte-format
            // Do with it what you want
            // ========================================================================
        }
        catch (Exception ex)
        { MessageBox.Show(ex.ToString(), "Error while retrieving"); }
        // Close and dispose streams
        stream.Close();
        stream.Dispose();
        nwStream.Close();
        nwStream.Dispose();
        ms.Close();
        ms.Dispose();
    }
