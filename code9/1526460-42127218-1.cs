    public async Task<string> CheckForDataAsync()
    {
        if (!stream.DataAvailable)
        {
            await Task.Delay(5);
            return "";
        }
        return await reader.ReadLineAsync();
    }
