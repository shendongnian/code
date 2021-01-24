    static IEnumerable<string> GetAllCombinations<T>(ISet<T> set, int length)
    {
        IEnumerable<string> getCombinations(string current)
        {
            if (current.Length == length)
            {
                yield return current;
            }
            else
            {
                foreach (var s in set)
                {
                    foreach (var c in getCombinations(current + s))
                    {
                        yield return c;
                    }
                }
            }
        }
        Debug.Assert(length <= set.Count());
        return getCombinations(string.Empty);
    }
