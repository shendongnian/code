    var random = new Random();
    Observable
        .Range(65, 26)
        .Select(char.ConvertFromUtf32)
        .Select((letter, index) =>
            Observable
                .FromAsync(() =>
                    Task.Delay(random.Next(5000))
                        .ContinueWith(t => (letter, index))))
        .Merge()
        .Do(tuple => Console.WriteLine($"{tuple.letter}:{tuple.index}"))
        .Buffer(Observable.Never<Unit>())
        .Subscribe(tuples =>
            Console.WriteLine($"{string.Join(",", tuples.OrderBy(t => t.index).Select(t => t.letter))}"));
