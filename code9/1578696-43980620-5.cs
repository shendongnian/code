    var factory = new TaskFactory();
            var tasks = new List<Task>();
            for (int i = 0; i < threadCount; i++)
            {
                int count = i;
                Task task = factory.StartNew(() =>
                {
                    processThread(startPoints[count], endPoints[count]);
                });
                tasks.Add(task);
                Console.WriteLine("Started for " + startPoints[i] + ", " + endPoints[i]);
            }
            Task.WaitAll(tasks.ToArray());
