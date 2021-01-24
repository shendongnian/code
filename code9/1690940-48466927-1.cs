    class MyHeaderDictionary : IHeaderDictionary
    {
        private readonly IHeaderDictionary _inner;
        public MyHeaderDictionary(IHeaderDictionary inner)
        {
            _inner = inner;
        }
        
        public IEnumerator<KeyValuePair<string, StringValues>> GetEnumerator()
        {
            foreach (var kvp in _inner)
            {
                if (kvp.Key.Equals(HeaderNames.SetCookie) && kvp.Value.Count > 1)
                {
                    int i = 0;
                    foreach (var stringValue in kvp.Value)
                    {
                        // Separate values as header names that differ by case
                        yield return new KeyValuePair<string, StringValues>(ModifiedHeaderNames[i], stringValue);
                        i++;
                    }
                }
                else
                {
                    yield return kvp;
                }
            }
        }
        
        // Implement all other IHeaderDictionary members as wrappers around _inner
    }
