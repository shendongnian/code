    public void BeginRead()
    {
        var buffer = new byte[4096];
        var ns = tcpClient.GetStream();
        ns.BeginRead(buffer, 0, buffer.Length, EndRead, buffer);
    }
