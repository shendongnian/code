    public IEnumerator<Country> GetEnumerator()
    {
        // Some iterator/loop which uses "yield return" for each item
        foreach (var item in items)
            yield return item;
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
