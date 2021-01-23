    class Program
    {
        static void Main(string[] args)
        {
            var pipeline = Observable
                .Defer(() => DoSomethingAsync().ToObservable())
                .Retry(2)
                .Catch<string, InvalidOperationException>(ex => Observable.Return("default"));
            pipeline
                .Do(Console.WriteLine)
                .Subscribe();
            Console.ReadKey();
        }
        private static int invocationCount = 0;
        private static async Task<string> DoSomethingAsync()
        {
            Console.WriteLine("Attempting DoSomethingAsync");
            await Task.Delay(TimeSpan.FromSeconds(2));
            ++invocationCount;
            if (invocationCount == 2)
            {
                return "foo";
            }
            throw new InvalidOperationException();
        }
    }
