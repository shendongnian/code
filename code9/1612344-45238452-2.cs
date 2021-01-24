    /// <summary>
    /// Sets the given keys to their respective values. If "not exists" is specified, this will not perform any operation at all even if just a single key already exists.
    /// </summary>
    /// <returns>True if the keys were set, else False</returns>
    /// <remarks>http://redis.io/commands/mset</remarks>
    /// <remarks>http://redis.io/commands/msetnx</remarks>
    Task<bool> StringSetAsync(KeyValuePair<RedisKey, RedisValue>[] values, When when = When.Always, CommandFlags flags = CommandFlags.None);
