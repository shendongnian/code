    public static int[] IndexesOf<T>(this List<T> findIn, T find)
    {
        var indexes = new List<int>();
        int startAt = 0;
        while (startAt > -1 && startAt < findIn.Count)
        {
            startAt = findIn.IndexOf(find, startAt);
            if (startAt > -1)
            {
                indexes.Add(startAt);
                startAt++;
            }
        }
        return indexes.ToArray();
    }
