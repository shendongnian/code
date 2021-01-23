    public class PartyMaker
        {
            private readonly SemaphoreSlim _slowStuffSemaphore = new SemaphoreSlim(1, 1);
            private readonly ConcurrentDictionary<int, int> _requestCounts = new ConcurrentDictionary<int, int>();
            private readonly ConcurrentDictionary<int, DateTime> _cache = new ConcurrentDictionary<int, DateTime>();
            public async Task<DateTime> ShakeItAsync(Argument argument)
            {
                var key = argument.GetHashCode();
                DateTime result;
                try
                {
                    if (!_requestCounts.ContainsKey(key))
                    {
                        _requestCounts[key] = 1;
                    }
                    else
                    {
                        ++_requestCounts[key];
                    }
                    var needNewRequest = _requestCounts[key] == 1;
                    await _slowStuffSemaphore.WaitAsync().ConfigureAwait(false);
                    if (!needNewRequest)
                    {
                        _cache.TryGetValue(key, out result);
                        return result;
                    }
                    _cache.TryAdd(key, default(DateTime));
                    result = await ShakeItSlowlyAsync().ConfigureAwait(false);
                    _cache[key] = result;
                    return result;
                }
                finally
                {
                    _requestCounts[key]--;
                    if (_requestCounts[key] == 0)
                    {
                        int temp;
                        _requestCounts.TryRemove(key, out temp);
                        _cache.TryRemove(key, out result);
                    }
                    _slowStuffSemaphore.Release();
                }
            }
            private async Task<DateTime> ShakeItSlowlyAsync()
            {
                await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
                return DateTime.UtcNow;
            }
        }
        public class Argument
        {
            public Argument(int value)
            {
                Value = value;
            }
            public int Value { get;  }
            public override int GetHashCode()
            {
                return Value.GetHashCode();
            }
        }
