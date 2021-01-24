    public IEnumerable<short> IntToShort(IEnumerable<int> iBuf)
    {
        foreach (var i in iBuf)
        {
            yield return (short)i;
        }
    }
