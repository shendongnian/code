    bool _disposed;
    public StartActivity1()
    {
        if(_disposed) return; // or throw exception.
        _object1 = new MyDisposableType1();
    }
    public StopActivity1()
    {
        _object1?.Dispose();
        _object1 = null;
    }
    //...
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
             _object1?.Dispose();
             _object2?.Dispose();            
             _disposed = true
        }
    }
