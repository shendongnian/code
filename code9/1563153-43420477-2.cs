    public class MyDisposable : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Disposing this disposable instance.");
        }
        // Note: This is not the right way to implement the dispose pattern. See
        // the MSDN docs on the recommended pattern.
        ~MyDisposable()
        {
            Dispose();
        }
    }
