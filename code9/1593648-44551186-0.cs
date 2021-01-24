    private int _count = 0;
    public bool Ongoing => Interlocked.CompareExchange(ref _count, 0, 0) > 0;
    public void Method1(object param)
    {
        new Thread(new ParameterizedThreadStart(Method2)).Start(param);
    }
    private void Method2(object param)
    {        
        lock (_lock)
        {
            _count++;
            // Something
            _count--;
        }
    }
