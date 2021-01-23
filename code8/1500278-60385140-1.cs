    using Microsoft.Extensions.Caching.Distributed;
    using StackExchange.Redis;
    private readonly IDistributedCache _cache;
    private readonly IConnectionMultiplexer _connectionMultiplexer;
    public CacheRepository(IDistributedCache cache, IConnectionMultiplexer connectionMultiplexer)
    {
        _cache = cache;
        _connectionMultiplexer = connectionMultiplexer;
    }
    public async Task RemoveWithWildCardAsync(string keyRoot)
    {
        if (string.IsNullOrWhiteSpace(keyRoot))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(keyRoot));
        // get all the keys* and remove each one
        await foreach (var key in GetKeysAsync(keyRoot + "*"))
        {
            await _cache.RemoveAsync(key);
        }
    }
    public async IAsyncEnumerable<string> GetKeysAsync(string pattern)
    {
        if (string.IsNullOrWhiteSpace(pattern))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(pattern));
        foreach (var endpoint in _connectionMultiplexer.GetEndPoints())
        {
            var server = _connectionMultiplexer.GetServer(endpoint);
            await foreach (var key in server.KeysAsync(pattern: pattern))
            {
                yield return key.ToString();
            }
        }
    }
    public IEnumerable<RedisFeatures> GetRedisFeatures()
    {
        foreach (var endpoint in _connectionMultiplexer.GetEndPoints())
        {
            var server = _connectionMultiplexer.GetServer(endpoint);
            yield return server.Features;
        }
    }
