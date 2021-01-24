    class Program
    {
        static void Main()
        {
            DoWork();
            // Will exit immediately
        }
        static async Task DoWork()
        {
            await Task.Delay(10000);
            // Should wait 10 seconds
        }
    }
