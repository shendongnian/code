    var task = Task.Factory.StartNew(delegate
    {
	   /// do something
    });
    this.CompleteTask(task, TaskContinuationOptions.OnlyOnRanToCompletion, delegate
    {
	   /// do something that use UI controls
    });
    public void CompleteTask(Task task, TaskContinuationOptions options, Action<Task> action)
    {
	   task.ContinueWith(delegate
	   {
		  action(task);
		  task.Dispose();
       }, CancellationToken.None, options, this.uiSyncContext);
    }
