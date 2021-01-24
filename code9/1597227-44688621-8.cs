    // Dummy lazy enumerable
    IEnumerable<Either<Exception, A>> Values()
    {
        for(int i = 0; i < 100; i++)
        {
            yield return Try(() => UnreliableExternalFunc(i)).ToEither();
        }
    }
