    static public async Task SendMessages()
    {
        if (_socket != null)
            await _socket.OutputStream.WriteAsync(btMessage.ToArray(), 0, btMessage.Count);
        btMessage.Clear();
    }
