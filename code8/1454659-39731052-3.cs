    private readonly object _lockobj = new Object();
    public void LockResource()
    {
        Monitor.Enter(_lockobj);
    }
    
    public bool WaitForResource()
    {
        //requires to be inside of a lock.
        //returns true if it is the lock holder.
        return Monitor.Wait(_lockobj);        
    }
    public void SignalAll()
    {
        Monitor.PulseAll(_lockobj);   
    }
    // Is very close to
    private readonly ManualResetEvent _lockobj = new ManualResetEvent(true);
    public bool LockResource()
    {
        //Returns true if it was able to perform the lock.
        return _lockobj.Reset();
    }
    
    public void WaitForResource()
    {
        //Does not require to be in a lock. 
        //if the _lockobj is in the signaled state this call does not block.
        _lockobj.WaitOne();      
    }
    public void SignalAll()
    {
        _lockobj.Set();
    }
