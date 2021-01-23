    class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            Interval.SetIntervalAsync(DoSomething, 1000, cts.Token);
            Console.ReadKey(); // cancel after first key press.
            cts.Cancel();
            Console.ReadKey();
        }
        public static void DoSomething()
        {
            Console.WriteLine("Hello World");
        }
    }
