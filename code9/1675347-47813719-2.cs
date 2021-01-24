    public static HashSet<string> GetNameSegments(string filename)
    {
        var segments = filename.Split(new char[] {'_', '-'}, StringSplitOptions.RemoveEmptyEntries).ToList();
        var matches = segments
            .Cartesian(segments, (x, y) => x == y ? null : x + y)
            .Where(z => z != null)
            .Concat(segments);
        return new HashSet<string>(matches);
    }
