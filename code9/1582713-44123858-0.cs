    private int count = 0;
    public int Count
    {
        get
        {
            return count;
        }
        set
        {
            // Only do something if the value is changing
            if (value != count)
            {
                DoSomething();
                count = value;
            }
        }
    }
