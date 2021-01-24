    public static class NameValueMapExtensions
    {
        public static IEnumerable<KeyValuePair<string, T>> AsEnumerable<T>(this NameValueMap map)
        {
            for (int i = 1; i <= map.Count; i++)
                yield return new KeyValuePair<string, T>(
                    map.Name[i], (T)map.Values[i]);
        }
    }
    // ...
    foreach (var item in context.AsEnumerable())
    {
        // item.Key: Name
        // item.Value: ...
    }
