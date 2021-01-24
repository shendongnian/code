    private readonly IStorage cache;
    public async Task<string> CacheCarouselAsync(IEnumerable<Image> images) {
        var token = Guid.NewGuid().ToString();
        await cache.SetAsync(token, images.Select(image => image.StandartResolutionURL).ToList());
        return token;
    }
