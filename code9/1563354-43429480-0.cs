        static ConcurrentQueue<string> consoleQueue = new ConcurrentQueue<string>();
        static ManualResetEventSlim itemEnqueuedEvent = new ManualResetEventSlim();
        static void WriteToConsoleLoop(object state)
        {
            var token = (CancellationToken)state;
            while (!token.IsCancellationRequested)
            {
                string entry;
                while (consoleQueue.TryDequeue(out entry))
                {
                    Console.WriteLine(entry);
                }
                try
                {
                    itemEnqueuedEvent.Wait(token);
                    itemEnqueuedEvent.Reset();
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
        }
        static void WriteToConsole(string entry)
        {
            consoleQueue.Enqueue(entry);
            itemEnqueuedEvent.Set();
        }
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            // Background or foreground, depends on how vital it is
            // to print everything in the queue before shutting down.
            var thread = new Thread(WriteToConsoleLoop) { IsBackground = true };
            thread.Start(cts.Token);
            WriteToConsole("Started...");
            // Do your stuff...
            cts.Cancel();
        }
