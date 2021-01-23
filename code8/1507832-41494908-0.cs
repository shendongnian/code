    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Run().Wait(); // Wait on each iteration.
            }
        }
        // Need to return Task to be able to await it.
        static async Task Run()
        {
            var task1 = Task.Delay(500);
            var task2 = DoSomethingAsync();
            await Task.WhenAll(task1, task2);
        }
        static async Task DoSomethingAsync()
        {
            Random r = new Random();
            int miliseconds = Convert.ToInt32(r.NextDouble() * 1000);
            await Task.Delay(miliseconds);
            Console.WriteLine(miliseconds);
        }
    }
