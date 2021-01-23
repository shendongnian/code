    public class OnDisposed : IDisposable
    {
        private readonly Action _disposeAction;
        public OnDisposed(Action disposeAction)
        {
            _disposeAction = disposeAction;
        }
        public void Dispose()
        {
            // ...
            if(_disposeAction != null)
                _disposeAction();
        }
    }
