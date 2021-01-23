    private readonly object _lockobj = new Object();
    public void LockResource()
    {
        Monitor.Enter(_lockobj);
    }
    public void FreeResource()
    {
        Monitor.Exit(_lockobj);
    }
    //Which is the same as
    private readonly AutoResetEvent _lockobj = new AutoResetEvent(true);
    public void LockResource()
    {
        _lockobj.WaitOne();
    }
    public void FreeResource()
    {
        _lockobj.Set();
    }
