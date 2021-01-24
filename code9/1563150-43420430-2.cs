    public void Dispose()
    {
        GC.SuppressFinalize(this);
        Dispose(true);
    }
    
    ~MyClass()
    {
        Dispose(false);
    }
    
    bool _isDisposed = false;
    protected virtual void Dispose(bool disposeing)
    {
        if(_isDisposed)
            return;
    
        _isDisposed = true;
    
        if(disposing)
        {
            //Disposed managed code here
        }
    
        //Dispose unmanaged code only here.
    }
