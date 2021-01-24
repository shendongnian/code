    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApplication3
    {
        class Program
        {
            static AutoResetEvent _restart = new AutoResetEvent(false);
            static CancellationTokenSource _cancellationSource = new CancellationTokenSource();
            static void Main()
            {
                var task = Task.Run(() => ControlLoop(2, _cancellationSource.Token, _restart));
                // After 5 seconds reset the process loop.
                Thread.Sleep(5000);
                Console.WriteLine("Restarting process loop.");
                RestartProcessLoop();
                Thread.Sleep(5000);
                Console.WriteLine("Stopping control loop.");
                Stop();
                Console.WriteLine("Waiting for control loop to terminate");
                task.Wait();
                Console.WriteLine("Control loop exited.");
            }
            public static void RestartProcessLoop()
            {
                _restart.Set();
            }
            public static void Stop()
            {
                _cancellationSource.Cancel();
                RestartProcessLoop();
            }
            public static async Task ControlLoop(int pollingIntervalSeconds, CancellationToken cancellation, AutoResetEvent restart)
            {
                while (!cancellation.IsCancellationRequested)
                {
                    await Task.Run(() => ProcessLoop(pollingIntervalSeconds, restart));
                }
            }
            public static void ProcessLoop(int pollingIntervalSeconds, AutoResetEvent restart)
            {
                Console.WriteLine("Beginning ProcessLoop()");
                var previousDateTime = DateTime.MinValue;
                while (!restart.WaitOne(TimeSpan.FromSeconds(pollingIntervalSeconds)))
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
