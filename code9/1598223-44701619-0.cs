    public static bool HasSameElementsWith<T>(
        this IEnumerable<T> collection1, IEnumerable<T> collection2)
    {
        var counts = new Dictionary<T, int>();
        foreach (var item in collection1)
        {
            counts.TryGetValue(item, out int count);
            count++;
            counts[item] = count;
        }
        foreach (var item in collection2)
        {
            counts.TryGetValue(item, out int count);
            if (count == 0)
                return false;
            count--;
            counts[item] = count;
        }
        return counts.Values.All(c => c == 0);
    }
