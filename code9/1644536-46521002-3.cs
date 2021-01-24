        // Run-Flag to gracefully exit loop.
        private static volatile bool _keepRunning = true;
        private static ManualResetEvent _exitRequest = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("Starting... {0} ", DateTime.Now);
            Console.CancelKeyPress += delegate(object sender, ConsoleCancelEventArgs e) {
                e.Cancel = true;
                MainClass._keepRunning = false;
            };            
            Task.Run(() => KillWinword); // Start Task on ThreadPool
            //You don't want to use Console.Read(); So ... wait for Ctrl-C?
            _exitRequest.WaitOne();
        }
        private static async Task KillWinword()
        {
            try
            {
                // Loop instead of recursion
                while(_keepRunning)
                {
                    // Do your checks here
                    DoKillWinword();
                    // Don't delay if exit is requested.
                    if(_keepRunning) await Task.Delay(1000);
                }
            }
            finally 
            {
            _exitRequest.Set();
            }
        }
        private static void DoKillWinword()
        {
            // TIPP: You should add some Exception handling in here!
            var procs = Process.GetProcesses();
            foreach (var proc in procs)
            {
                if (proc.ProcessName == "WINWORD")
                {
                    TimeSpan runtime;
                    runtime = DateTime.Now - proc.StartTime;
                    if (DateTime.Now > proc.StartTime.AddSeconds(20))
                    {
                        proc.Kill();
                    }
                }
            }
        }
