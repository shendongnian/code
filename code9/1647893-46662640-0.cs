    public IEnumerable<int> SomeIterator()
    {
        for(int I = 0; I < 10; I++) yield return I;
    }
    public IEnumerable<int> SomeIterator()
    {
        return Enumerable.Range(0, 10); // return result of another iterator.
    }
