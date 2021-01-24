    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApplication3
    {
        class Program
        {
            static AutoResetEvent _restart = new AutoResetEvent(false);
            static void Main()
            {
                CancellationTokenSource cancellationSource = new CancellationTokenSource(10000); // Cancels after 10s.
                var task = Task.Run(() => ControlLoop(2, cancellationSource.Token, _restart));
                // After 5 seconds reset the process loop.
                Thread.Sleep(5000);
                Console.WriteLine("Restarting process loop.");
                RestartProcessLoop();
                Thread.Sleep(5000);
            
                Console.WriteLine("Waiting for control loop to terminate");
                task.Wait();
                Console.WriteLine("Control loop exited.");
            }
            public static void RestartProcessLoop()
            {
                _restart.Set();
            }
            public static async Task ControlLoop(int pollingIntervalSeconds, CancellationToken cancellation, AutoResetEvent restart)
            {
                while (!cancellation.IsCancellationRequested)
                {
                    await Task.Run(() => ProcessLoop(pollingIntervalSeconds, cancellation, restart));
                }
            }
            public static void ProcessLoop(int pollingIntervalSeconds, CancellationToken cancellation, AutoResetEvent restart)
            {
                Console.WriteLine("Beginning ProcessLoop()");
                var previousDateTime = DateTime.MinValue;
                var terminators = new[]{cancellation.WaitHandle, restart};
            
                while (WaitHandle.WaitAny(terminators, TimeSpan.FromSeconds(pollingIntervalSeconds)) == WaitHandle.WaitTimeout)
                {
                    if (CheckForUpdate())
                    {
                        Update(previousDateTime);
                        previousDateTime = DateTime.Now;
                    }
                }
                Console.WriteLine("Ending ProcessLoop()");
            }
            public static void Update(DateTime previousDateTime)
            {
            }
            public static bool CheckForUpdate()
            {
                Console.WriteLine("Checking for update.");
                return true;
            }
        }
    }
