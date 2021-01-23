    async Task<bool> Scan(string filePath)
    {
        Scanner.Scan(filePath);
        var result = Scanner.CheckStatus();
        while(result == false)
        {
            await Task.Delay(2000);
            result = Scanner.CheckStatus();
        }
        return result
    }
