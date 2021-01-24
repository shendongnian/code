        private static volatile bool _keepRunning = true;
        static void Main(string[] args)
        {
            Console.WriteLine("Starting... {0} ", DateTime.Now);
            
            Task.Run(() => KillWinword); // Start Task on ThreadPool
            Console.Read();
            _keepRunning = false;
        }
        private static async Task KillWinword()
        {
            while(_keepRunning)
            {
                // Do your checks here
                // Don't delay if exit is requested.
                if(_keepRunning) await Task.Delay(1000);
            }
        }
