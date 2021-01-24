    using System;
    using System.Threading;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main()
            {
                var cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(150));
                Console.WriteLine("Started at time " + DateTime.Now);
                SomeMethod(cancellationSource.Token);
                Console.WriteLine("Finiehd at time " + DateTime.Now);
            }
            static void SomeMethod(CancellationToken cancellation)
            {
                do
                {
                    Thread.Sleep(10); // Some code goes here.
                }
                while (!cancellation.IsCancellationRequested);
            }
        }
    }
