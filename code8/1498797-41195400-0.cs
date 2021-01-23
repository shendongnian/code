        for (int i = 0; i < 20; i++)
        {
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Entering task " + Task.CurrentId);
                semaphore.Wait(); //only from 2 - 10 threads can be at the time
                Console.WriteLine("Processing task " + Task.CurrentId);
            });
        }
