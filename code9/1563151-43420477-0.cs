    public class MyDisposable : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Disposing this disposable instance.");
        }
        ~MyDisposable()
        {
            Dispose();
        }
    }
