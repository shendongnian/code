    private void Start()
    {
        // blocks a thread waiting for FillList() to finish
        FillList().Wait();
    }
    private async void FillList()
    {
        var gamesList = new List<string>();
        gamesList.AddRange(await GetGamesSet());
        gamesList.AddRange(await GetGamesSet());
        
        /* more stuff */
    }
    private async Task<List<string>> GetGamesSet()
    {
        await Task.Delay(200);
        return new List<string> { "result1", "result 2" };
    }
