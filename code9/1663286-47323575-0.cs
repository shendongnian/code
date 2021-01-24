    public void modify()
    {
        for (int i = 0; i < 1000000000; i++)
        {
            Interlocked.Increment(ref count);
            Interlocked.Decrement(ref count); 
        }
    }
