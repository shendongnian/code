    static ConcurrentDictionary<string, Lazy<AsyncLock>> _keyLocks = new ConcurrentDictionary<string, Lazy<AsyncLock>>();
    public async Task<IActionResult> Index(int articleId)
    {    
        var key = CacheKeysFor.Article.ById(articleId);
        ArticleModel cacheEntry;
        cacheEntry = _cache.Get<ArticleModel>(key);
    
        if (cacheEntry == null)
        {
            var keyLock = _keyLocks.GetOrAdd(key, _ => new Lazy<AsyncLock>(() => new AsyncLock())).Value;
            using (await keyLock.LockAsync())
            {
                if (cacheEntry == null)
                {
                    cacheEntry = SomeDatabaseCall
                    _cache.Set(key, cacheEntry, TimeSpan.FromSeconds(60));
                }
    
            }
        }
    
        return View(cacheEntry);
    }
