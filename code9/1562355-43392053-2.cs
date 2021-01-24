    static void Main(string[] args)
    {
        Execute();
        Console.ReadKey();
    }
    private static async void Execute()
    {
        var intervals = Observable.Interval(TimeSpan.FromSeconds(2)).StartWith(0);
        var evenNumbers = Enumerable.Range(1, 1200).Where(a => a % 2 == 0);
        var evenNumbersAtIntervals = intervals.Zip(evenNumbers, (_, num) => num);
        try
        {
            await evenNumbersAtIntervals.ForEachAsync(
                x => Console.WriteLine("OnNext: {0}", x)
            );
            Console.WriteLine("Complete");
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception " + e);
        }
    }
