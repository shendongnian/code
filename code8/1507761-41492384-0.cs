    private async void TryToConnectToHost()
    {
        // host IP Address and communication port
        string ipAddress = Properties.Settings.Default.HostIPaddr;
        int port = 9100;
        //Try to Connect with the host
        try
        {
            using (TcpClient client = new TcpClient())
            {
                await client.ConnectAsync(ipAddress, port);
                CanConnectToHost = client.Connected; // no need for if
            }
        }
        catch (Exception exception)
        {
            CanConnectToHost = false;
        } 
    }
