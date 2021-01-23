    async Task<bool> Scan(string filePath)
    {
        var result = false;
        Scanner.Scan(filePath);
        result = Scanner.CheckStatus();
        while(result == false)
        {
            await Task.Delay(2000);
            result = Scanner.CheckStatus();
        }
        return result
    }
