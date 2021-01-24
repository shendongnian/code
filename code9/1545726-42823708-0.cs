    void Main()
    {
       Util.Cache (TakesSomeTime).Dump();
    }
    
    int TakesSomeTime()
    {
       Thread.Sleep(2000);
       return 42;
    }
