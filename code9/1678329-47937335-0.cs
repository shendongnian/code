    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Temp
    {
        internal class Program
        {
            // this is the `Timer`
            private static async Task CallWithInterval(Action action, TimeSpan interval, CancellationToken token)
            {
                while (true)
                {
                    await Task.Delay(interval, token);
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
    
                    action();
                }
            }
    
            // your method which is called with some interval
            private static void DoSomething()
            {
                Console.WriteLine("ding!");
            }
    
            // usage sample
            private static void Main()
            {
                // we need it to add the ability to stop timer on demand at any time
                var cts = new CancellationTokenSource();
    
                // start Timer
                var task = CallWithInterval(DoSomething, TimeSpan.FromSeconds(1), cts.Token);
    
                // continue doing another things - I stubbed it with Sleep
                Thread.Sleep(5000);
    
                // if you need to stop timer, let's try it!
                cts.Cancel();
    
                // check out, it really stopped!
                Thread.Sleep(2000);
            }
        }
    }
