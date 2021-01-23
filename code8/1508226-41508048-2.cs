    public async Task<bool> IsConnected()
    {
        using (TcpClient client = new TcpClient())
        { 
            var clientTask = client.ConnectAsync(ipAddress, port);
            var delayTask = Task.Delay(2000);
    
            var completedTask = await Task.WhenAny(new[] {clientTask, delayTask});
            return completedTask == clientTask;
        }
    }
