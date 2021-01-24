    public GameObject _GameObject;
    
    void Start()
    {
        Application.runInBackground = true;
    
        int iterations = 1000000;
    
        //TEST 1
        Stopwatch stopwatch1 = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            bool active = gameObject.activeSelf;
        }
        stopwatch1.Stop();
    
        //TEST 2
        Stopwatch stopwatch2 = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            bool active = _GameObject.activeSelf;
        }
        stopwatch2.Stop();
        //SHOW RESULT
        WriteLog(String.Format("gameObject: {0}", stopwatch1.ElapsedMilliseconds));
        WriteLog(String.Format("Cached _GameObject: {0}", stopwatch2.ElapsedMilliseconds));
    }
    
    void WriteLog(string log)
    {
        UnityEngine.Debug.Log(log);
    }
