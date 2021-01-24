        public Func<TIn, Task<TOut>> MemoizeAsync<TIn, TOut>(Func<TIn, Task<TOut>> f)
        {
            var cache = new Dictionary<TIn, TOut>();
            TOut Run (TIn x)
            {
                if (cache.ContainsKey(x))
                {
                    return cache[x];
                }
                var result = await f(x);
                cache[x] = result;
                return result;
            }
            return Run;
        }
