    // Dummy lazy enumerable
    IEnumerable<Try<int>> Values()
    {
        for(int i = 0; i < 100; i++)
        {
            yield return Try(() => UnreliableExternalFunc(i));
        }
    }
