        static void Main()
        {
            var config = new JobHostConfiguration();
            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }
            var watcher = new WebJobsShutdownWatcher();
            
          
            Task.Run(() =>
            {
                bool isCancelled = false;
                while (!isCancelled)
                {
                    if (watcher.Token.IsCancellationRequested)
                    {
                        Console.WriteLine("WebJob cancellation Token Requested!");
                        isCancelled = true;
                    }
                }
            }, watcher.Token);
            var host = new JobHost(config);
            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();
        }
