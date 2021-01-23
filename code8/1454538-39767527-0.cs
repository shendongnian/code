    private async void btnListen_Click(object sender, RoutedEventArgs e)
    {
            socket = new DatagramSocket();
            socket.MessageReceived += Socket_MessageReceived;
            socket.Control.MulticastOnly = true;
            await socket.BindServiceNameAsync(serverPort);
            socket.JoinMulticastGroup(serverHost);
            SendWithExistingSocket(socket, "");//send an empty message immediately
    }
    private async void SendWithExistingSocket(DatagramSocket socket, String text)
    {
        if (socket != null)
        {
            Stream stream = (await socket.GetOutputStreamAsync(serverHost, serverPort)).AsStreamForWrite();
            using (var writer = new StreamWriter(stream))
            {
                writer.WriteLine(text);
                await writer.FlushAsync();
            }
        }
    }
