    private int GetCount(IDictionary<string, int> counts, string item)
    {
      int count;
      if (!counts.TryGetValue(item, out count))
        count = 0;
      count++;
      counts[item] = count;
      return count;
    }
    private IEnumerable<string> GetItems(IEnumerable<string> items)
    {
      // Initialize dict for counts with appropriate comparison
      var counts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
      foreach(var item in items)
        yield return string.Format("{0}[{1}]", item, GetCount(counts, item));
    }
        
