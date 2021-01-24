    public async Task WaitAllEvenIfException(this Task[] tasksToWaitFor)
    {
        // wait until all completed, even if one of them raises exception
        While (!tasksToWaitFor.All(task => task.IsCompleted)
        {
             // not all completed yet
             try
             {
                  await Task.WhenAll(tasksToWaitFor);
             }
             catch (AggregateException exc)
             {
                 // one or more of the Tasks threw exception,
                 // don't handle now, wait until all Completed
             }
        }
    }
