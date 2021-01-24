    static private IEnumerable<int> toIntArray(string[] strArray)
    {
        foreach (string str in strArray)
        {
            foreach (char c in str)
            {
                yield return (int)char.GetNumericValue(c);
            }
        }
    }
