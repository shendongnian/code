    public class EventObserver : IObserver<T>
    {
        private readonly ObservedEvents _events = new ObservedEvents();
        private readonly TaskCompletionSource<T> _source;
        private readonly SynchronizationContext _capturedContext;
        public EventObserver()
        {
            _source = new TaskCompletionSource<T>();
            
            // Capture the current synchronization context.
            _capturedContext = SynchronizationContext.Current;
        }
        void OnCompleted()
        {
            // Apply the captured synchronization context.
            SynchronizationContext.SetSynchronizationContext(_capturedContext);
            _source.SetResult(...);
        }
    }
