    static void Main(string[] args)
    {
        var intervals = Observable.Interval(TimeSpan.FromSeconds(2));
        var evenNumbers = Enumerable.Range(1, 1200).Where(a => a % 2 == 0);
        var evenNumbersAtIntervals = intervals.Zip(evenNumbers, (_, num) => num);
        var results = evenNumbersAtIntervals.Subscribe(
                        x => Console.WriteLine("OnNext: {0}", x),
                        ex => Console.WriteLine("OnError: {0}", ex.Message),
                        () => Console.WriteLine("OnComplete")
        );
        Console.ReadKey(); // wait for keypress while observable sequence runs assynchronously in the background
    }
