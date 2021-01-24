    public static IEnumerable<IEnumerable<T>> GetAllDistinctCombinations<T>(
        this IEnumerable<IEnumerable<T>> sources)
    {
        if (sources == null)
           throw new ArgumentNullException(nameof(sources));
        return GetAll(sources, Enumerable.Empty<T>());
        IEnumerable<IEnumerable<T>> GetAll(IEnumerable<IEnumerable<T>> currentSources, IEnumerable<T> current)
        {
            foreach (var source in currentSources)
            {
                foreach (var s in source)
                {
                    IEnumerable<T> newCombination;
                    if (!current.Contains(s))
                    {
                        newCombination = current.Concat(new[] { s });
                        yield return newCombination;
                    }
                    else
                    {
                        newCombination = current;
                    }
                    foreach (var comb in GetAll(currentSources.Except(
                        new[] { source }), newCombination))
                    {
                        yield return comb;
                    }
                }
            }
        }
    }
