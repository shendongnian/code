    static void Main(string[] args)
    {
        while (_PromptContinue())
        {
            // create the bank account instance
            BankAccount account = new BankAccount();
            // create an array of tasks
            Task<int>[] tasks = new Task<int>[10];
            // create the thread local storage
            ThreadLocal<int> tlsBalance = new ThreadLocal<int>();
            ThreadLocal<(int Id, int Count)> tlsIds = new ThreadLocal<(int, int)>(
                () => (Thread.CurrentThread.ManagedThreadId, 0), true);
            for (int i = 0; i < 10; i++)
            {
                int k = i;
                // create a new task
                tasks[i] = new Task<int>((stateObject) =>
                {
                    // get the state object and use it
                    // to set the TLS data
                    tlsBalance.Value = (int)stateObject;
                    (int id, int count) = tlsIds.Value;
                    tlsIds.Value = (id, count + 1);
                    Console.WriteLine($"task {k}: thread {id}, initial value {tlsBalance.Value}");
                    // enter a loop for 1000 balance updates
                    for (int j = 0; j < 1000; j++)
                    {
                        // update the TLS balance
                        tlsBalance.Value++;
                    }
                    // return the updated balance
                    return tlsBalance.Value;
                }, account.Balance);
                // start the new task
                tasks[i].Start();
            }
            // Make sure this thread isn't busy at all while the thread pool threads are working
            Task.WaitAll(tasks);
            // get the result from each task and add it to
            // the balance
            for (int i = 0; i < 10; i++)
            {
                account.Balance += tasks[i].Result;
            }
            // write out the counter value
            Console.WriteLine("Expected value {0}, Balance: {1}", 10000, account.Balance);
            Console.WriteLine("{0} thread ids used: {1}",
                tlsIds.Values.Count,
                string.Join(", ", tlsIds.Values.Select(t => $"{t.Id} ({t.Count})")));
            System.Diagnostics.Debug.WriteLine("done!");
            _Countdown(TimeSpan.FromSeconds(20));
        }
    }
    private static void _Countdown(TimeSpan delay)
    {
        System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
        TimeSpan remaining = delay - sw.Elapsed,
            sleepMax = TimeSpan.FromMilliseconds(250);
        int cchMax = $"{delay.TotalSeconds,2:0}".Length;
        string format = $"\r{{0,{cchMax}:0}}", previousText = null;
        while (remaining > TimeSpan.Zero)
        {
            string nextText = string.Format(format, remaining.TotalSeconds);
            if (previousText != nextText)
            {
                Console.Write(format, remaining.TotalSeconds);
                previousText = nextText;
            }
            Thread.Sleep(remaining > sleepMax ? sleepMax : remaining);
            remaining = delay - sw.Elapsed;
        }
        Console.Write(new string(' ', cchMax));
        Console.Write('\r');
    }
    private static bool _PromptContinue()
    {
        Console.Write("Press Esc to exit, any other key to proceed: ");
        try
        {
            return Console.ReadKey(true).Key != ConsoleKey.Escape;
        }
        finally
        {
            Console.WriteLine();
        }
    }
