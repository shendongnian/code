    public static IObservable<string> CreatePermutations(this IObservable<string> source, 
                                                         IObservable<string> other)
    {
        return Observable.Create<string>(obs =>
        {
            var or = other.Replay();
            var sequence = source.SelectMany(i => or.Select(j => $"{i}{j}"));                             
            
            return new CompositeDisposable(new [] { sequence.Subscribe(obs),
                                                    or.Connect()
                                                  });
        });
    }
