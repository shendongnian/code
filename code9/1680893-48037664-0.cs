    struct TaskCast<TSource, TDestination>
        where TSource : TDestination
    {
        readonly Task<TSource> task;
    
        public TaskCast(Task<TSource> task)
        {
            this.task = task;
        }
    
        public Awaiter GetAwaiter() => new Awaiter(task);
    
        public struct Awaiter
            : System.Runtime.CompilerServices.INotifyCompletion
        {
            System.Runtime.CompilerServices.TaskAwaiter<TSource> awaiter;
    
            public Awaiter(Task<TSource> task)
            {
                awaiter = task.GetAwaiter();
            }
    
            public bool IsCompleted => awaiter.IsCompleted;    
            public TDestination GetResult() => awaiter.GetResult();    
            public void OnCompleted(Action continuation) => awaiter.OnCompleted(continuation);
        }
    }
