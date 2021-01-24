    public static Dictionary<int, int> Duplicates(IEnumerable<int> sequence)
    {
        var duplicates = new Dictionary<int, int>();
        foreach (int i in sequence)
        {
            if(duplicates.ContainsKey(i))
                duplicates[i]++;
            else
                duplicates.Add(i, 1);
        }
        return duplicates;
    }
