    public class HangfireQueue
    {
        private readonly IList<Expression<Action>> _queuedItems;
    
        public HangfireQueue()
        {
            _queuedItems = new List<Expression<Action>>();
        }
    
        public virtual void EnqueueTask(Expression<Action> methodCall)
        {
            _queuedItems.Add(methodCall);
        }
    
        public virtual void EnqueueTask<T>(Expression<Action<T>> methodCall, T p1)
        {
            _queuedItems.Add(() => methodCall.Compile()(p1));
        }
    
        public virtual void EnqueueTask<T1,T2>(Expression<Action<T1,T2>> methodCall, T1 p1, T2 p2)
        {
            _queuedItems.Add(() => methodCall.Compile()(p1, p2));
        }
    
        public void CommitUnitOfWork()
        {
            foreach (Expression<Action> item in _queuedItems)
            {
                BackgroundJob.Enqueue(item);
            }
        }
    }
