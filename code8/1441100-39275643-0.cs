            Func<Task> action = async () =>
            {
                lock (lock_x)
                {
                    Console.WriteLine("Entered");
                    Thread.Sleep(5000);
                    Console.WriteLine("Exited");
                }
            };
