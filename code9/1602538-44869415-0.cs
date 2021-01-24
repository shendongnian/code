    public static IEnumerable<KeyValuePair<DateTime, int>> Filter(IEnumerable<KeyValuePair<DateTime, int>> values)
    {
        KeyValuePair<DateTime, int>? previous = null;
        foreach (var kvp in values.OrderBy(v => v.Key))
        {
            if (previous == null || (kvp.Key - previous.Value.Key).TotalMinutes >= 1)
            {
                previous = kvp;
                yield return kvp;
            }
        }
    }
