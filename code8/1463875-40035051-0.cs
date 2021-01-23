    public static int testVal=0;
    
    void Awake()
    {
        SetVal();
        Debug.Log(testVal); // print 10
    }
    
    void SetVal()
    {
        testVal = 10;
    }
