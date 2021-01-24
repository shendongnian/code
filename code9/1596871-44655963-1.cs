    public static IEnumerable<IEnumerable<T>> SplitArray<T>(this IEnumerable<T> s,T splitItem)
    {
        // First we get all the indexes where the string is found,
        // adding the last index of the array
        var indexes = s.Select((b, i) => b.Equals(splitItem) ? i : -1).Where(i => i != -1)
                       .Union(new int[] { s.Count() }).ToArray();
                    
        int skip = 0; //variable to know where the next chunk starts
        foreach (int index in indexes)
        {
            IEnumerable<T> array = s.Skip(skip).Take(index - skip).ToArray();
            yield return array; //we return the chunk
            skip = index+1;
        }
    }
