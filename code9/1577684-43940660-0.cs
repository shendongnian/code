            class PCQueue : IDisposable
            {
                private BlockingCollection<Task> _taskQueue = new BlockingCollection<Task>();
                public PCQueue(int workerCount)
                {
                    for (int i = 0; i < workerCount; i++)
                        Task.Factory.StartNew(Consume);
                }
    
                public Task Enqueue(Action action, CancellationToken cancelToken = default(CancellationToken))
                {
                    //! A task object can either be generated using TaskCompletionSource or instantiated directly (an unstarted or cold task!).
                    var task = new Task(action, cancelToken);
                    _taskQueue.Add(task); //? Create a cold task and enqueue it.
                    return task;
                }
    
                public Task<TResult> Enqueue<TResult>(Func<TResult> func, CancellationToken cancelToken = default(CancellationToken))
                {
                    var task = new Task<TResult>(func, cancelToken);
                    _taskQueue.Add(task);
                    return task;
                }
    
                void Consume()
                {
                    foreach (var task in _taskQueue.GetConsumingEnumerable())
                    {
                        try
                        {
                            //! We run the task synchronously on the consumer's thread.
                            if (!task.IsCanceled) task.RunSynchronously();
                        }
                        catch (InvalidOperationException)
                        {
                            //! Handle the unlikely event that the task is canceled in between checking whether it's canceled and running it. 
                            // race condition!
                        }
                    }
                }
    
                public void Dispose() => _taskQueue.CompleteAdding();
            }
