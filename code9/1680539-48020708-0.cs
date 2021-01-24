    private static IEnumerable<IEnumerable<T>> GetAllSubSequences<T>(
        IEnumerable<T> sequence)
    {
        IEnumerable<IEnumerable<T>> getSubSequences(IEnumerable<T> current)
        {
            if (current.Count() > 0)
            {
                for (var length = 1; length <= current.Count(); length++)
                {
                    yield return current.Take(length);
                }
                foreach (var subSequence in GetAllSubSequences(current.Skip(1)))
                {
                    yield return subSequence;
                }
            }
        }
        return getSubSequences(sequence);
    }
