    public static ICollection<string[]> SplitAt(this string input, char target, int length, StringSplitOptions, opts = StringSplitOptions.None, bool trim = false)
    {
        string[] itens = input.Split(new char[] { target }, opts);
        if (trim) itens = itens.Select(s => s.Trim()).ToArray();
        return InternalSplitAt(itens, length);
    }
    private static ICollection<string[]> InternalSplitAt(string[] itens, char target, int length, bool trim = false)
    {
        var collectionToReturn = new List<string[]>();
        
        var loops = itens.Length / length;
        for (int i = 0; i < loops; i++)
        {
            var arrayToAdd = new string[length];
            Array.Copy(itens, i * length, newArray, 0, length);
            ret.Add(arrayToAdd);
        }
        
        return collectionToReturn;
    }
