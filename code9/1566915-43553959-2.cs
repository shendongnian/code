       /// <summary>
       /// An async mutex.  When awaiting for the lock to be released, instead of blocking the calling thread,
       /// a continuation will resume execution
       /// </summary>
       
       ///<example>
       ///   using( await _asyncLock.LockAsync() ) {
       ///      use shared resource
       ///   }
       /// </example>
       
       /// Original author:
       /// Stephen Toub
       /// https://blogs.msdn.microsoft.com/pfxteam/2012/02/12/building-async-coordination-primitives-part-6-asynclock/
      
       public class AsyncLock {
    
           public struct Releaser : IDisposable {
              private readonly AsyncLock _toRelease;
              internal Releaser(AsyncLock toRelease) {
                 _toRelease = toRelease;
              }
              public void Dispose() {
                 _toRelease._semaphore.Release();
              }
           }
    
           private SemaphoreSlim _semaphore;
           private Task<Releaser> _releaserTask;
    
           public AsyncLock() {
              _semaphore = new SemaphoreSlim(1, 1);
              _releaserTask = Task.FromResult(new Releaser(this));
           }
    
           public Task<Releaser> LockAsync() {
              var wait = _semaphore.WaitAsync();
              if( wait.IsCompleted )
                 return _releaserTask;
              var continuation = wait.ContinueWith( (_, state) => new Releaser((AsyncLock)state),
                                                    this, 
                                                    CancellationToken.None, 
                                                    TaskContinuationOptions.ExecuteSynchronously, 
                                                    TaskScheduler.Default);
    
              return continuation;
           }
    
           
    
           public Releaser Lock() {
              _semaphore.Wait();
              return _releaserTask.Result;
           }
        }
    }
 
