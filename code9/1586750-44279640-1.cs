    public static async Task<YourClass> CreateAsync(…)
    {
       var result = new YourClass(…);
       await result.InitializeAsync();
       return result;
    }
    private async Task InitializeAsync()
    {
       TeamRows2 = await Scrape();
    }
