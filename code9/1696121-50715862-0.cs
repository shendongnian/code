    private async Task AcceptLoopWorker()
    {
        int count = 0;
    
        while (true)
        {
            try
            {
                BroadcastMessage("Listening for incoming connection...", DataSyncMessageType.Debug);
    
                using (var serverSocket = BluetoothAdapter.DefaultAdapter.ListenUsingRfcommWithServiceRecord(nameof(GameDataSyncService), Java.Util.UUID.FromString(UUID)))
                using (var clientSocket = serverSocket.Accept()) // This call blocks until a connection is established.
                {
                    BroadcastMessage(string.Format("Connection received from {0}. Sending data...", clientSocket.RemoteDevice.Name), DataSyncMessageType.Info);
                    var bytes = System.Text.Encoding.UTF8.GetBytes(string.Format("Hello World - {0}", string.Join(" ", Enumerable.Repeat(Guid.NewGuid(), ++count))));
                    await clientSocket.OutputStream.WriteAsync(bytes, 0, bytes.Length);
                }
    
                await Task.Delay(1000 * 3); // Give the master some time to close the connection from their end
            }
            catch (Java.IO.IOException ex)
            {
                BroadcastMessage(string.Format("IOException {0}: {1}", ex.GetType().FullName, ex.Message), DataSyncMessageType.Debug);
            }
            catch (Java.Lang.Exception ex)
            {
                BroadcastMessage(string.Format("Exception {0}: {1}", ex.GetType().FullName, ex.Message), DataSyncMessageType.Debug);
            }
        }
    }
    private async Task SyncDataWorker()
    {
        BroadcastMessage("Beginning data sync...");
    
        foreach (var bondedDevice in BluetoothAdapter.DefaultAdapter.BondedDevices.OrderBy(d => d.Name))
        {
            try
            {
                using (var clientSocket = bondedDevice.CreateRfcommSocketToServiceRecord(Java.Util.UUID.FromString(UUID)))
                {
                    BroadcastMessage(string.Format("Connecting to {0}...", bondedDevice.Name));
    
                    if (!clientSocket.IsConnected)
                    {
                        clientSocket.Connect();
                    }
    
                    if (clientSocket.IsConnected)
                    {
                        byte[] buffer = new byte[1024];
                        var readTask = clientSocket.InputStream.ReadAsync(buffer, 0, buffer.Length);
                        if (await Task.WhenAny(readTask, Task.Delay(1000)) != readTask)
                        {
                            BroadcastMessage("Read timeout...", DataSyncMessageType.Error);
                            break;
                        }
    
                        int bytes = readTask.Result;
                        BroadcastMessage(string.Format("Read {0} bytes.", bytes), DataSyncMessageType.Success);
    
                        if (bytes > 0)
                        {
                            var text = System.Text.Encoding.UTF8.GetString(buffer.Take(bytes).ToArray());
                            BroadcastMessage(text, DataSyncMessageType.Success);
                            break;
                        }
                    }
                    else
                    {
                        BroadcastMessage("Not Connected...", DataSyncMessageType.Error);
                    }
                }
            }
            catch (Java.IO.IOException ex)
            {
                BroadcastMessage(string.Format("IOException {0}: {1}", ex.GetType().FullName, ex.Message), DataSyncMessageType.Debug);
            }
            catch (Java.Lang.Exception ex)
            {
                BroadcastMessage(string.Format("Exception {0}: {1}", ex.GetType().FullName, ex.Message), DataSyncMessageType.Debug);
            }
        }
    
        await Task.Delay(1000 * 3);
    
        BroadcastMessage("Data sync complete!");
        lock (locker)
        {
            running = false;
        }
    }
