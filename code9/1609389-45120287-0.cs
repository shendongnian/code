    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start, you have 10 seconds!");
            ShowMessageAfterDelay(TimeSpan.FromSeconds(10), "Time has lappsed!").Wait();
            Console.ReadLine();
        }
        static async Task ShowMessageAfterDelay(TimeSpan timeSpan, string message)
        {
            await Task.Delay(timeSpan);
            Console.WriteLine(message);
        }
    }
