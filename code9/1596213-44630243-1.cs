    public class Program
    {
        public static void Main()
        {
            RunAsync().Wait();
        }
        public static async Task RunAsync()
        {
            var limiter = new TaskLimiter(10, TimeSpan.FromSeconds(1));
            // create 100 tasks 
            var tasks = Enumerable.Range(1, 100)
               .Select(e => limiter.LimitAsync(() => DoSomeActionAsync(e)));
            // wait unitl all 100 tasks are completed
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
        static readonly Random _rng = new Random();
        public static async Task DoSomeActionAsync(int i)
        {
            await Task.Delay(150 + _rng.Next(150)).ConfigureAwait(false);
            Console.WriteLine("Completed Action {0}", i);
        }
    }
