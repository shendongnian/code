        var exceptions = new ConcurrentQueue<Exception>();
        try
        {
            var actionBlock = new ActionBlock<ParallelWorker_EmailNotification>(async worker =>
                {
                    try
                    {
                        await worker.SendNotification();
                    }
                    catch (Exception ex)
                    {
                        exceptions.Enqueue(ex);
                    }
                }, new ExecutionDataflowBlockOptions
                        {
                         MaxDegreeOfParallelism = DataflowBlockOptions.Unbounded                        
                        }
                );
            
            foreach (Email mail in listEmails)
            {
                actionBlock.Post(new ParallelWorker_EmailNotification(mail));
            }
            actionBlock.Complete();
            actionBlock.Completion.Wait();
        }
        catch (Exception ex)
        {
            exceptions.Enqueue(ex);
        }
