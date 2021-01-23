    public static int testVal=0;
    
    void Awake()
    {
        SetVal(ref testVal);
        Debug.Log(testVal); // print 10
    }
    
    void SetVal(ref int testVal)
    {
        testVal = 10;
    }
