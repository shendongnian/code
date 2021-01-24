    class Program
    {
        static void Main(string[] args)
        {
            Operation op = new Operation();
            var tokenSource = new CancellationTokenSource();
            Task.Factory.StartNew( async () => await op.LongRunningApplication(tokenSource.Token));
            while(true)
            {
                Console.WriteLine("PRINT STOP for Cancellation...");
                var str = Console.ReadLine();
                if(string.Compare(str, "Stop", true) == 0)
                {
                    Console.WriteLine("Cancellation Requested...");
                    tokenSource.Cancel();
                    Task.Delay(TimeSpan.FromSeconds(30)).Wait(); // Making Sure that It stops gracefully since this is console app
                    break;
                }
            }
            Console.WriteLine("Completed");
        }
    }
    public class Operation
    {
        public async Task LongRunningApplication(CancellationToken token)
        {
            Console.WriteLine("Starting long Running application....");
            while (true)
            {
                await Task.Delay(1000);   // Your Operation
                Console.WriteLine("Wating...");
                for (int i = 0; i < 30; i++)
                {
                    await Task.Delay(TimeSpan.FromSeconds(10));  // Wait For 5 Mins (10 sec , 30 intervals)
                    if (token != null && token.IsCancellationRequested)
                    {
                        Console.WriteLine("Stopping GraceFully..");
                        return;
                    }
                }
            }
        }
    }
