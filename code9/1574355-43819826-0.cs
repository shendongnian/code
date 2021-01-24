    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace hw
    {
        class Program
        {
            private const int delay = 1000;
            private static Random random = new Random();
            private static ManualResetEvent resetEvent = new ManualResetEvent(false);
    
            static async Task Handle()
            {
                Console.WriteLine($"tick tack... {random.Next()}");
                await Task.Delay(delay);
                await Handle();
            }
    
            static void Main(string[] args)
            {
                Task.Factory.StartNew(async() => await Handle());
                Console.CancelKeyPress += (sender, eventArgs) => resetEvent.Set();
                resetEvent.WaitOne();
            }
        }
    }
