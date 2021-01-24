    CacheMenuList= ((List<Menu>)cache.Get(CacheKey)).Select(
        x => new Menu2 () {
            Property1 = x.Property1,
            Property2 = x.Property2,
            Property3 = x.Property3,
            Property4 = x.Property4
        }
    ).ToList();
