        // Run-Flag to gracefully exit loop.
        private static volatile bool _keepRunning = true;
        static void Main(string[] args)
        {
            Console.WriteLine("Starting... {0} ", DateTime.Now);
            
            Task.Run(() => KillWinword); // Start Task on ThreadPool
            Console.Read(); // Hitting Enter will end Program.
            _keepRunning = false;
        }
        private static async Task KillWinword()
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
