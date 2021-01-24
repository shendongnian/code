    IVsFontAndColorCacheManager cacheManager = this.GetService(typeof(SVsFontAndColorCacheManager)) as IVsFontAndColorCacheManager;
    cacheManager.ClearAllCaches();
    var guid = new Guid("00000000-0000-0000-0000-000000000000");
    cacheManager.RefreshCache(ref guid);
    guid = new Guid("{A27B4E24-A735-4d1d-B8E7-9716E1E3D8E0}"); // Text editor category
