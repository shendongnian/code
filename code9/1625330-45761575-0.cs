    private const string CachedEntriesKey = "SOME-STATIC-KEY";
    
    [HttpGet("{url}", Name = "GetPost")]
    public IActionResult GetById(string url, bool includeExcerpt)
    {
        Dictionary<string, Post> cacheEntries;
        if (!_cache.TryGetValue(CachedEntriesKey, out cacheEntries))
        {
            cacheEntries = new Dictionary<string, Post>();
            _cache.Set(CachedEntriesKey, cacheEntries);
        }
    
        var entryKey = $"GetById{url}{includeExcerpt}";
        if (!cacheEntries.ContainsKey(entryKey))
        {
            return NotFound(); // by the way, why you do that instead of adding to the cache?
        }
    
        return new ObjectResult(cacheEntries[entryKey]);
    }
