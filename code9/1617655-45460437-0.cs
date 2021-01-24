    private Dictionary<int, string> localCache = new Dictionary<int, string>();
    public string C(int id)
    {
        if (localCache.ContainsKey(id))
        {
            return localCache[id];
        }
        else
        {
            string returnedFromApi = SomeApiCall(id);
            localCache.Add(id, returnedFromApi);
            return returnedFromApi;
        }
    }
