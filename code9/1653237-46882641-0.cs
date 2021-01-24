    public static bool HaveDuplicates(this IEnumerable<int> values)
    {
        var set = new HashSet<int>();
        foreach (var value in values)
        {
            if (set.Add(value) == false)
            {
                return true;
            }
        }
        return false;
    }
