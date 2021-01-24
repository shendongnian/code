    public static string QueryRegistry (RegistryKey root, string path)
    {
        List<IDisposable> resourceTracker = new List<IDisposable>() { root };
        try 
        {
            var ret = path.Split(Path.DirectorySeparatorChar)
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
        finally
        {
            foreach (var res in resourceTracker)
            {
                res.Dispose();
            }
        }
    }
