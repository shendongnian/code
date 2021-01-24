    public class SimpleClass : IDisposable
    {
        // managed resources SqlConnection implements IDisposable as well.
        private SqlConnection _connection;
        private bool _disposed;
        // implementing IDisposable
        public void Dispose()
        {
            // Here in original Dispose method we call protected method with parameter true,
            // saying that this object is being disposed.
            this.Dispose(true);
            
            // Then we "tell" garbage collector to suppress finalizer for this object because we are releasing
            // its memory and doesnt need to be finalized. Calling finalizer(destructor) of a given type is expensive
            // and tweaks like this help us improve performance of the application.
            GC.SuppressFinalize(this);
        }
        // Following the best practices we should create another method in the class 
        // with parameter saying whether or not the object is being disposed.
        // Its really important that this method DOES NOT throw exceptions thus allowing to be called multiple times 
        protected virtual void Dispose(bool disposing)
        {
            // another thing we may add is flag that tells us if object is disposed already
            // and use it here
            if (_disposed) { return; }
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
            _disposed = true;
       
            // call base Dispose(flag) method if we are using hierarchy.
        }
    }
