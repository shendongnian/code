    public class Foo3 : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            // Cleanup
        }
        ~Foo3()
        {
            Dispose(false);
        }
    }
