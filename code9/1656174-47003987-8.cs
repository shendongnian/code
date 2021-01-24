    public static IEnumerable<Task<T>> AsItCompletes<T>(this IEnumerable<Task<T>> taskList)
            {
                var tasks = taskList.ToList();
                var sources = tasks.Select(x => new TaskCompletionSource<T>()).ToList();
    
                int currentIndex = -1;
                foreach (var task in tasks)
                {
                    task.ContinueWith(completed =>
                    {
                        var next = sources[Interlocked.Increment(ref currentIndex)];
                        if (completed.IsFaulted)
                        {
                            next.SetException(completed.Exception);
                        }
                        else if (completed.IsCanceled)
                        {
                            next.SetCanceled();
                        }
                        else
                        {
                            next.SetResult(completed.Result);
                        }
                    }, TaskContinuationOptions.ExecuteSynchronously);
                }
    
                return sources.Select(source => source.Task);
            }
