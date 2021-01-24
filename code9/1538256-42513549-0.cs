    HttpBaseProtocolFilter filter = new HttpBaseProtocolFilter();
    // Setting it to .NoCache always forces a new request
    filter.CacheControl.ReadBehavior = HttpCacheReadBehavior.NoCache;
    filter.CacheControl.WriteBehavior = HttpCacheWriteBehavior.Default;
    HttpClient client = new HttpClient(filter);
    // .. your request code
