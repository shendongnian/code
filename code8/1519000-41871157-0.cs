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
    
        public void CommitUnitOfWork()
        {
            foreach (Expression<Action> item in _queuedItems)
            {
                BackgroundJob.Enqueue(item);
            }
        }
    }
