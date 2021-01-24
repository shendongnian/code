    public static class SessionStorageFactory
    {
        public static Dictionary<string, ISessionStorageContainer> _nhSessionStorageContainer = new Dictionary<string, ISessionStorageContainer>();
        public static ISessionStorageContainer GetStorageContainer(string key)
        {
            ISessionStorageContainer storageContainer = _nhSessionStorageContainer.ContainsKey(key) ? _nhSessionStorageContainer[key] : null;
            if (storageContainer == null)
            {
                if (HttpContext.Current == null)
                {
                    storageContainer = new ThreadSessionStorageContainer(key);
                    _nhSessionStorageContainer.Add(key, storageContainer);
                }
                else
                {
                    storageContainer = new HttpSessionContainer(key);
                    _nhSessionStorageContainer.Add(key, storageContainer);
                }
            }
            return storageContainer;
        }
    }
