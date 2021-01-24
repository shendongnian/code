    public class CrazyDisposable : IDisposable
    {
        public int Counter { get; private set; }
        public void Dispose() => Counter++;
    }
