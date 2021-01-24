        var exceptions = new ConcurrentQueue<Exception>();
        try
        {
            var tasks = listEmails.Select(mail => new ParallelWorker_EmailNotification(mail))
                                  .Select(async worker =>
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
