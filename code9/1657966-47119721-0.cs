    public Task ReceiveAsync(IContext context)
    {
         var task = GetSomeAsyncTask(...);
         context.ReenterAfter(task, t => {
             //code inside here will run when the task completes.
             //still preserving actor concurrency constraints
         });
    }
