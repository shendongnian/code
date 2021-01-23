    public static int testVal=0;
    void Awake()
    {
        Debug.Log(testVal); // print 0
        SetVal();
        Debug.Log(testVal); // print 10
    }
    void SetVal()
    {
        testVal = 10;
    }
