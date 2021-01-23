    public class RNetEngine : IDisposable
    {
      private bool _disposed;
      private REngine _rEngine;
      private static readonly object Lock = new object();
      private REngine Engine
      {
        get
        {
          if (_rEngine == null)
          {
            lock (Lock)
            {
            if (_rEngine == null)
              {              
                _rEngine = REngine.GetInstance();
              }
            }
          }
          return _rEngine;
        }
      }
      public void Evaluate(string expression)
      {
        Engine.Evaluate(expression);
      }
      public void Dispose()
      {
        Dispose(true);
        GC.SuppressFinalize(this);
      }
      protected virtual void Dispose(bool disposing)
      {
        if (_disposed)
        {
          return;
        }
        if (disposing)
        {
          if (_rEngine != null && !_rEngine.Disposed)
          {
            _rEngine.Dispose();
          }
        }
        _disposed = true;
      }
    }
