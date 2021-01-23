    public int testVal=0;
    
    void Awake()
    {
        testVal = SetVal();
        Debug.Log(testVal); // print 10
    }
    
    int SetVal()
    {
        return 10;
    }
