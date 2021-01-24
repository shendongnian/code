    public class Foo2 : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            // Cleanup
        }
    }
