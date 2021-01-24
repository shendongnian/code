    public async Task<string> GetHtmlAsync(string url)
    {
        using (var client = new HttpClient())
        using (var response = await client.GetAsync(url))
        {
            response.EnsureSuccessStatusCode();
            using (var content = response.Content)
            {
                return await content.ReadAsStringAsync();
            }
        }
    }
    
    // Wrapper for Polly to create an async retry policy
    public async Task<TResult> RetryAsync<TResult, TException>(
        Func<Task<TResult>> taskInitiator, int retries, int seconds) where TException : Exception
    {
        return await Policy
                   .Handle<TException>()
                   .WaitAndRetryAsync(retries, wait => TimeSpan.FromSeconds(seconds))
                   .ExecuteAsync(async () => await taskInitiator());
    }
    
    // Call the method, it will retry 12 times with a gap of 5 seconds between tries
    var html = await RetryAsync<string, HttpRequestException>(
        () => GetHtmlAsync("https://www.google.co.uk"), 12, 5);
