    private volatile int _count = 0;
    public bool Ongoing
    {
        get
        {
            return _count > 0;
        }
    }
    public void Method1(object param)
    {
        new Thread(new ParameterizedThreadStart(Method2)).Start(param);
    }
    private void Method2(object param)
    {
        Interlocked.Increment(ref _count);
        lock (_lock)
            {
                // Something
            }
        Interlocked.Decrement(ref _count);
    }
