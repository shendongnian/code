    public class CachedAlbumRepository : IAlbumRepository
    {
        private readonly IAlbumRepository _albumRepository;
    public CachedAlbumRepository(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }
 
    private static readonly object CacheLockObject = new object();
 
    public IEnumerable<Album> GetTopSellingAlbums(int count)
    {
        Debug.Print("CachedAlbumRepository:GetTopSellingAlbums");
        string cacheKey = "TopSellingAlbums-" + count;
        var result = HttpRuntime.Cache[cacheKey] as List<Album>;
        if (result == null)
        {
            lock (CacheLockObject)
            {
                result = HttpRuntime.Cache[cacheKey] as List<Album>;
		if (result == null)
                {
                    result = _albumRepository.GetTopSellingAlbums(count).ToList();
                    HttpRuntime.Cache.Insert(cacheKey, result, null, 
                        DateTime.Now.AddSeconds(60), TimeSpan.Zero);
                }
            }
        }
        return result;
    }
    }
