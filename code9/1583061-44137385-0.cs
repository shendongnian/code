        public Func<TIn, TOut> Memoize<TIn, TOut>(Func<TIn, TOut> f)
        {
            var cache = new Dictionary<TIn, TOut>();
            TOut Run (TIn x)
            {
                if (cache.ContainsKey(x))
                {
                    return cache[x];
                }
                var result = f(x);
                cache[x] = result;
                return result;
            }
            return Run;
        }
