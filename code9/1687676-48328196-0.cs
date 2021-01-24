    public async Task<string> GetFinalUrl(string url)
    {
        string finalUrl;
        try
        {
            finalUrl = await FollowDestinationUrl(url).TimeoutAfter(TimeSpan.FromSeconds(2));
        }
        catch (TimeoutException)
        {
            finalUrl = null;
        }
        return finalUrl;
    }
