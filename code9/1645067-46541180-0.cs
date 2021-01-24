    void Start()
    {
    
        int iterations = 10000000;
    
        //TEST 1
        Stopwatch stopwatch1 = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            int test1 = (int)0.5f;
        }
        stopwatch1.Stop();
    
        //TEST 2
        Stopwatch stopwatch2 = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            int test2 = Mathf.FloorToInt(0.5f);
        }
        stopwatch2.Stop();
    
        //SHOW RESULT
        WriteLog(String.Format("(int)float: {0}", stopwatch1.ElapsedMilliseconds));
        WriteLog(String.Format("Mathf.FloorToInt: {0}", stopwatch2.ElapsedMilliseconds));
    }
    
    void WriteLog(string log)
    {
        UnityEngine.Debug.Log(log);
    }
