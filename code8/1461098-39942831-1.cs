    ManualResetEvent mre = new ManualResetEvent(false);
    if (Interlocked.CompareExchange(ref m_kernelEvent, mre, null) != null)
    {    
        ((IDisposable)mre).Dispose();
    }
    // There is a ---- between checking IsCancellationRequested and setting the event.
    // However, at this point, the kernel object definitely exists and the cases are:
    //   1. if IsCancellationRequested = true, then we will call Set()
    //   2. if IsCancellationRequested = false, then NotifyCancellation will see that the event exists, and will call Set().
    if (IsCancellationRequested)
        m_kernelEvent.Set();
    return m_kernelEvent;
