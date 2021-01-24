    class Foo : IDisposable
    {
        ~Foo()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.managedResource.Dispose();
            }
            // Cleanup unmanaged resource
            UnsafeClose(this.handle);
            // If the base class is IDisposable object, make sure you call:
            // base.Dispose();
        }
    }
