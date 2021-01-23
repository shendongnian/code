    public static IEnumerable<T> Generate(Func<T> generator)
    {
        while(true)
            yield return generator.Invoke();
    }
