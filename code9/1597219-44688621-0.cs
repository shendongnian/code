    using LanguageExt;
    using static LanguageExt.Prelude;
    // Dummy lazy enumerable
    IEnumerable<int> Values()
    {
        for(int i = 0; i < 100; i++)
        {
            yield return UnreliableExternalFunc(i);
        }
    }
    // Convert to a lazy sequence
    Seq<int> seq = Seq(Values());
    // Invoke external function that takes an IEnumerable
    ExternalFunction(seq);
    // Calling it again won't evaluate it twice
    ExternalFunction(seq);
