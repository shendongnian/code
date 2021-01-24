        Dictionary<Tuple<int, string>, T> cache = new
              Dictionary<Tuple<int, string>, T>();
    
        public void updateCache()
        {
    
            foreach (var sr in searchResults)
            {
                var key = new Tuple<int, string>(sr.Number, sr.FileName);
                cache[key] = sr;
            }
        }
