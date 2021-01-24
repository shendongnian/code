    public static IEnumerable<IEnumerable<T>> GetAllPossibleCombinations<T>(
        IEnumerable<T> stream, int length)
    {
        return getAllCombinations(stream, ImmutableStack<T>.Empty);
        IEnumerable<IEnumerable<T>> getAllCombinations<T>(IEnumerable<T> currentData, ImmutableStack<T> combination)
        {
            if (combination.Count == length)
                yield return combination;
            foreach (var d in currentData)
            {
                var newCombination = combination.Push(d);
                foreach (var c in getAllCombinations(currentData.Except(new[] { d }), newCombination))
                {
                    yield return c;
                }
            }
        }
    }
