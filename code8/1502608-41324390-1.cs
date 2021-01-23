        public class TasksPool
        {
            public int MaxSize { get; private set; }
            public TasksPool(int maxSize)
            {
                if (maxSize < 1) throw new IndexOutOfRangeException("Should be 1 or more");
                MaxSize = maxSize;
                _semaphore = new SemaphoreSlim(maxSize-1);
            }
            private readonly SemaphoreSlim _semaphore;
            public void Add(Task t, CancellationToken token)
            {
                _semaphore.Wait(token);
                if (token.IsCancellationRequested) return;
                t.ContinueWith(q => _semaphore.Release(), token);
            }
        }
