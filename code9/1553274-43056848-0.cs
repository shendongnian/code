        static void Run()
        {
            var tasks = new List<Task>();
            for (int i = 0; i < 5; i++)
            {
                tasks.Add(Task.Factory.StartNew(Process, TaskCreationOptions.LongRunning));
            }
            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException)
            { }        
        }
