    public IEnumerable<IEnumerable<int>> GetNestedDigits()
    {
        yield return GetNestedEnumerable();
    }
    public IEnumerable<int> GetNestedEnumerable()
    {
        yield return 1;
    }
