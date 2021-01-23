    class Program
    {
        static void Main(string[] args)
        {
            SetInterval(() => Console.WriteLine("Hello World"), TimeSpan.FromSeconds(2));
            SetInterval(() => Console.WriteLine("Hello Stackoverflow"), TimeSpan.FromSeconds(4));
            Thread.Sleep(TimeSpan.FromMinutes(1));
        }
        public static async Task SetInterval(Action action, TimeSpan timeout)
        {
            await Task.Delay(timeout).ConfigureAwait(false);
            action();
            SetInterval(action, timeout);
        }
    }
