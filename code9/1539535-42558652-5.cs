    public static string QueryRegistry (RegistryKey root, string path)
    {
        string ret = null;
        using (var resourceTracker = new DisposableCollection() { root })
        {
            ret = path.Split(Path.DirectorySeparatorChar)
            .Aggregate(root, (r, k) =>
            {
                var key = r?.OpenSubKey(k);
                if (key != null) 
                {
                    resourceTracker.Add(key);
                }
                return key;
            }).GetValue(null).ToString();
        }
        return ret;
    }
