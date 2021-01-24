    public class AsyncLock
    {
       private TaskCompletionSource<object> _lastSection;
          
       public AsyncLock()
       {
          _lastSection = new TaskCompletionSource<object>();
          _lastSection.SetResult(null);
       }
    
       public class ReleaseLock : IDisposable
       {
          private readonly TaskCompletionSource<object> _tcs;
    
          public ReleaseLock(TaskCompletionSource<object> tcs)
          {
             _tcs = tcs;
          }
    
          public void Dispose()
          {
             _tcs.SetResult(null);
          }
       }
    
       /// <summary>
       /// Enters and locks a critical section as soon as the currently executing task has left the section.
       /// The critical section is locked until the returned <see cref="IDisposable"/> gets disposed.
       /// </summary>
       public Task<ReleaseLock> EnterAsync()
       {
          var newTcs = new TaskCompletionSource<object>();
          var toAwait = Interlocked.Exchange(ref _lastSection, newTcs);
          return toAwait.Task.ContinueWith((_, s) => new ReleaseLock(newTcs), newTcs, TaskContinuationOptions.ExecuteSynchronously);
       }
    }
