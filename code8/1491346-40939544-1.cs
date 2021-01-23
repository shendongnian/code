    private int a;
    private volatile bool x;
    public void Publish()
    {
        a = 1;
        x = true;
    }
    public void Read()
    {
        if (x)
        {
            // if we observe x == true, we will always see the preceding write to a
            Debug.Assert(a == 1); 
        }
    }
