    public static IObservable<string> CreatePermutations(this IObservable<string> source, 
                                                         IObservable<string> other)
    {
        return Observable.Create<string>(obs =>
        {
            var sr = source.Replay();
            var or = other.Replay();
            var mergedSequence = source.SelectMany(i => or.Select(j => $"{i}{j}")).Merge(
                                 other.SelectMany(i => sr.Select(j => $"{j}{i}")));                          
            
            return new CompositeDisposable(new [] { sr.Connect(), 
                                                    or.Connect(),
                                                    mergedSequence.Subscribe(obs)
                                                  });
        });
    }
