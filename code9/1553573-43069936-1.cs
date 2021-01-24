    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApp3
    {
        class Program
        {
            static void Main()
            {
                var test = new Program();
                // Create a cancellation token source that cancels itself after 10 seconds:
                var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(10));
                // Create and run the task:
                var sw = Stopwatch.StartNew();
                var checkCFOPTask = Task.Run(() => test.CheckCFOPExists(cancellation.Token));
                Console.WriteLine("Waiting for task to finish.");
                Console.WriteLine($"Task returned: {checkCFOPTask.Result} after {sw.ElapsedMilliseconds} ms");
            }
            private bool CheckCFOPExists(CancellationToken cancel)
            {
                TimeSpan retryDelay = TimeSpan.FromMilliseconds(500);
                while (true)
                {
                    if (tryToFindTheThing()) // Blocking call.
                        return true;
                    if (cancel.WaitHandle.WaitOne(retryDelay))
                        return false;
                }
            }
            bool tryToFindTheThing()
            {
                return false;  // Your implementation goes here.
            }
        }
    }
