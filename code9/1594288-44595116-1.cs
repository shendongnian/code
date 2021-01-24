     public ActionResult Index()
            {
                var client = new MemcachedClient();
    
                string myCacheKey = "MyCacheKey";
                client.Store(Enyim.Caching.Memcached.StoreMode.Set, myCacheKey, "If you see this it worked.");  // set the cache.
                string myCachedString = client.Get<string>(myCacheKey);
    
                ViewBag.MyCache = myCachedString ?? "**** SORRY,  DIDN'T WORK..***..";
                return View();
    
            }
