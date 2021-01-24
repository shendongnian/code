    public static IEnumerable<string[]> SplitArrayByString(this string[] s,string splitString)
    {
        // First we get all the indexes where the string is found,
        // adding the last index of the array
        var indexes = s.Select((b, i) => b == splitString ? i : -1).Where(i => i != -1)
                       .Union(new int[] { s.Length }).ToArray();
        int skip = 0; //variable to know where the next chunk starts
        foreach (int index in indexes)
        {
            string[] array = s.Skip(skip).Take(index - skip).ToArray();
            yield return array; //we return the chunk
            skip = index+1;
        }
    }
