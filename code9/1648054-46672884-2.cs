    // you can use CacheProfiles or manually pass in the arguments, it doesn't matter.
    // either way, no caching will take place if the app was launched with debugging
    [DynamicOutputCache(CacheProfile = "Month")]
    public ViewResult contact()
    {
        return View();
    }
