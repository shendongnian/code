    public static void Merge(Regions first, Regions second)
    {
        if (ReferenceEquals(first, null))
            throw new ArgumentNullException(nameof(first));
        if (ReferenceEquals(second, null))
            throw new ArgumentNullException(nameof(second));
        first.ParentName = first.ParentName.Merge(second.ParentName).ToArray();
    }
    private static IEnumerable<string> Merge(this IEnumerable<string> first, IEnumerable<string> second)
    {
        if (ReferenceEquals(first, null))
            throw new ArgumentNullException(nameof(first));
        if (ReferenceEquals(second, null))
            throw new ArgumentNullException(nameof(second));
        foreach (var f in first)
        {
            yield return f.Merge(second, ',');
        }
    }
    private static string Merge(this string first, IEnumerable<string> second, char separator)
    {
        Debug.Assert(first != null);
        Debug.Assert(second != null);
        var firstSplitted = first.Split(separator);
        foreach (var s in second)
        {
            var sSplitted = s.Split(separator);
            if (firstSplitted.Intersect(sSplitted).Any())
                return string.Join(separator.ToString(), firstSplitted.Union(sSplitted));
        }
        return first;
    }
