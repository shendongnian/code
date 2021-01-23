    public static IEnumerable<int> NumbersBiggerThanTheFollowingOnes(IList<int> numbers)
    {
        if (numbers.Count <= 0)
            yield break;
        int max = numbers[numbers.Count - 1];
        yield return max; // Last element is considered bigger than the "following" ones.
        for (int i = numbers.Count - 2; i >= 0; --i)
        {
            if (numbers[i] <= max)
                continue;
            max = numbers[i];
            yield return max;
        }
    }
