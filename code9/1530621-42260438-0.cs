    public IEnumerator<Country> GetEnumerator()
    {
        for (var item in items)
            yield return item;
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
