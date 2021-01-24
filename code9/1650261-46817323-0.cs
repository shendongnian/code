    public class SemaphoreQueueItem<T> : IDisposable
    {
        private bool Disposed;
        private readonly EventWaitHandle WaitHandle;
        public readonly T Resource;
        public SemaphoreQueueItem(EventWaitHandle waitHandle, T resource)
        {
            WaitHandle = waitHandle;
            Resource = resource;
        }
        public void Dispose()
        {
            if (!Disposed)
            {
                Disposed = true;
                WaitHandle.Set();
            }
        }
    }
    public class SemaphoreQueue<T> : IDisposable
    {
        private readonly T[] Resources;
        private readonly AutoResetEvent[] WaitHandles;
        private bool Disposed;
        private ConcurrentQueue<TaskCompletionSource<SemaphoreQueueItem<T>>> Queue = new ConcurrentQueue<TaskCompletionSource<SemaphoreQueueItem<T>>>();
        public SemaphoreQueue(T[] resources)
        {
            Resources = resources;
            WaitHandles = Enumerable.Range(0, resources.Length).Select(_ => new AutoResetEvent(true)).ToArray();
        }
        public SemaphoreQueueItem<T> Wait(CancellationToken cancellationToken)
        {
            return WaitAsync(cancellationToken).Result;
        }
        public Task<SemaphoreQueueItem<T>> WaitAsync(CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<SemaphoreQueueItem<T>>();
            Queue.Enqueue(tcs);
            Task.Run(() => WaitHandle.WaitAny(WaitHandles.Concat(new[] { cancellationToken.WaitHandle }).ToArray())).ContinueWith(task =>
            {
                if (Queue.TryDequeue(out var popped))
                {
                    var index = task.Result;
                    if (cancellationToken.IsCancellationRequested)
                        popped.SetResult(null);
                    else
                        popped.SetResult(new SemaphoreQueueItem<T>(WaitHandles[index], Resources[index]));
                }
            });
            return tcs.Task;
        }
        public void Dispose()
        {
            if (!Disposed)
            {
                foreach (var handle in WaitHandles)
                    handle.Dispose();
                Disposed = true;
            }
        }
    }
