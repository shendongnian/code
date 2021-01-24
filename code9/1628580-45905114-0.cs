    private static IEnumerable<IEnumerable<T>> Permute<T>(List<T> prefix, List<T> suffix)
    {
        for (var i = 0; i < suffix.Count; ++i)
        {
            var newPrefix = new List<T>(prefix) {suffix[i]};
            var newSuffix = new List<T>(suffix.Take(i).Concat(suffix.Skip(i + 1)));
            if (newSuffix.Count == 0)
            {
                yield return newPrefix;
                continue;
            }
            foreach (var permutation in Permute(newPrefix, newSuffix))
                yield return permutation;
        }
    }
