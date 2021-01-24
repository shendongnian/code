        var exceptions = new ConcurrentQueue<Exception>();
        try
        {
            List<ParallelWorker_EmailNotification> workers = new List<ParallelWorker_EmailNotification>();
            foreach (Email mail in listEmails)
            {
                workers.Add(new ParallelWorker_EmailNotification(mail));
            }
            var tasks = workers.Select(async worker =>
            {
                try
                {
                    await worker.SendNotification();
                }
                catch (Exception ex)
                {
                    exceptions.Enqueue(ex);
                }
            });
            await Task.WhenAll(tasks);
        }
        catch (Exception ex)
        {
            exceptions.Enqueue(ex);
        }
