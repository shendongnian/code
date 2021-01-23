    public sealed class SynchronousProgress<T> : IProgress<T>
    {
      private readonly Action<T> _callback;
      public SynchronousProgress(Action<T> callback) { _callback = callback; }
      void IProgress<T>.Report(T data) => callback(data);
    }
