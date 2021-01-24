    public class Program
    {
        static CancellationTokenSource _cts;
        public static void Main()
        {
            _cts = new CancellationTokenSource();
            Task delayTask = Task.Run(async delegate
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                Cancel();
            });
            Task.Run(async () => await Task.WhenAny(Loop(_cts), delayTask)).Wait();
        }
        public static void Cancel()
        {
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
                Console.WriteLine("Cancellation Requested");
            }
        }
        public static async Task Loop(CancellationTokenSource cts)
        {
            while (cts != null && !cts.IsCancellationRequested)
            {
            }
            Console.WriteLine("Thead did not complete.");
        }
    }
