      You could do something like this: 
     ConcurrentDictionary<Tuple<int, string>, T> cache = new 
             ConcurrentDictionary<Tuple<int, string>, T>();
            public void updateCache()
            {
              
                foreach (var sr in searchResults) {
                    var key = new Tuple<int, string>(sr.Number, sr.FileName);
                    if (!cache.ContainsKey(key))
                    {
                        cache[key] = sr;
                    }
                }
            }
