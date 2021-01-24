        public static async Task<IEnumerable<T2>> ProcessEachAsync<T1, T2>(IEnumerable<T1> src, Func<T1, Task<T2>> func, int dop)
        {
            using (var semSlim = new SemaphoreSlim(dop))
            {
                var result = new ConcurrentBag<T2>();
                Func<T1, Task> getTask = async (x) =>
                {
                    try
                    {
                        await semSlim.WaitAsync();
                        var res = await func(x);
                        result.Add(res);
                    }
                    finally
                    {
                        semSlim.Release();
                    }
                };
                await Task.WhenAll(src.Select(x => getTask(x)));
                return result;
            }
        }
