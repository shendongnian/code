    source
        .Do(_ => { 
                  throw new SomeException();
            }, 
                exception => Console.WriteLine(exception.ToString()) // log exceptions from source stream,
                () => {})
        .Retry()
        .Subscribe(
            l => Console.WriteLine($"OnNext {l}"),
            //      exception => Console.WriteLine(exception.ToString()), // Would be logging this in production
            () => Console.WriteLine("OnCompleted")
        );
