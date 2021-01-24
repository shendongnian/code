    public static class DictionaryExtensions
    {
      public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dic, List<KeyValuePair<TKey, TValue>> itemsToAdd)
      {
        itemsToAdd.ForEach(x => dic.Add(x.Key, x.Value));
      }
    }
