    public static T[] RandomlySelectedItems<T>(IEnumerable<T> items, int n, Random rng)
    {
        var result = new T[n];
        int index = 0;
        int count = 0;
        foreach (var item in items)
        {
            if (index < n)
            {
                result[count++] = item;
            }
            else
            {
                int r = rng.Next(0, index + 1);
                if (r < n)
                    result[r] = item;
            }
            ++index;
        }
        if (index < n)
            throw new ArgumentException("Input sequence too short");
        return result;
    }
