    static IEnumerable<string> GetAllCombinations<T>(IEnumerable<T> set, int length)
    {
        IEnumerable<string> NextCombination(string current)
        {
            if (current.Length == length)
            {
                yield return current;
            }
            else
            {
                foreach (var s in set)
                {
                    foreach (var c in NextCombination(current + s))
                    {
                        yield return c;
                    }
                }
            }
        }
