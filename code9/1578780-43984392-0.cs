    public int[] GetMissingNumbers(int[] provided, int maxLength)
    {
        var numbersBeyondEndOfProvidedRange = Enumerable.Range(1, provided.Length + maxLength);
        return numbersBeyondEndOfProvidedRange.Except(provided).Take(maxLength).ToArray();
    }
