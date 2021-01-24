    public void OnNavigatingTo(NavigationParameters parameters)
    {
        Task.Run(async () =>
        {
            await GetCachedValuesAsync();
        });
        ClipRefernce = GenerateRefernce(clips);
    }
    public async Task  GetCachedValuesAsync()
    {
        try
        {
            clips = await BlobCache.LocalMachine.GetObject<List<Clip>>("clips");
        }
        catch (KeyNotFoundException ex)
        {
            clips = new List<Clip>();
        }
    }
