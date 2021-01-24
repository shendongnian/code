    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApp
    {
        class Program
        {
            // Cancellation Tokens - https://docs.microsoft.com/en-us/previous-versions/dd997289(v=vs.110)
            private static readonly CancellationTokenSource canToken = new CancellationTokenSource();
    
            static async Task Main(string[] args)
            {
                Console.WriteLine("Application has started. Ctrl-C to end");
    
                Console.CancelKeyPress += (sender, eventArgs) =>
                {
                    Console.WriteLine("Cancel event triggered");
                    canToken.Cancel();
                    eventArgs.Cancel = true;
                };
    
                await Worker();
    
                Console.WriteLine("Now shutting down");
                await Task.Delay(1000);
            }
    
            async static Task Worker()
            {
                while (!canToken.IsCancellationRequested)
                {
                    // do work       
                    Console.WriteLine("Worker is working");
                    await Task.Delay(1000); // arbitrary delay
                }
            }
        }
    }
