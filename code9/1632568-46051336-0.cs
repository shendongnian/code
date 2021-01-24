    class FunctionXCaller
    {
        private Task mTask;
        private BlockingCollection<TaskCompletionSource<TResult>> queue = new BlockingCollection<TaskCompletionSource<TResult>>();
    
        public FunctionXCaller()
        {
             mTask = Task.Run( () => WorkerMethod );
        }
    
        private void WorkerMethod()
        {
             while( !queue.IsCompleted )
             {
                  TaskCompletionSource<TResult> tcs = queue.take();
                  tcs.TrySetResult(FunctionX());
             }
        }
    
        public Task<TResult> CallXAsync()
        {
             TaskCompletionSource<TResult> tcs = new TaskCompletionSource<TResult>();
             queue.Add(tcs);
             return tcs.Task;
        }
    }
