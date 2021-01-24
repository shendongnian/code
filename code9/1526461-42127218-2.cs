    public async Task<string> AllReadLineAsync()
    {
        string data = "", packet = "";
        foreach (var client in clients)
        {
            data = await client.CheckForDataAsync();
            if (data != string.Empty)
                packet += string.Format($"[client] {data}\n");   
        }
        
        return packet;
    }
