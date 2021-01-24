    public class NoSynchronizationContextScope : IDisposable
    {
        private readonly SynchronizationContext synchronizationContext;
        public NoSynchronizationContextScope()
        {
            synchronizationContext = SynchronizationContext.Current;
            SynchronizationContext.SetSynchronizationContext(null);
        }
        public void Dispose() => SynchronizationContext.SetSynchronizationContext(synchronizationContext);
    }
    
    void fn() 
    {
       using (new NoSynchronizationContextScope())
       {
           fnAsync().Wait();
           // or 
           // var result = fnAsync().Result(); 
           // in case you have to wait for a result
       }
    }
