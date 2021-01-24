    void Start()
    {
        List<int> list = new List<int>(6000000);
        for (int i = 0; i < 6000000; i++)
        {
            list.Add(UnityEngine.Random.Range(1, 10));
        }
        int[] arr = list.ToArray();
    
        int chk = 0;
        Stopwatch watch = Stopwatch.StartNew();
        for (int rpt = 0; rpt < 100; rpt++)
        {
            int len = list.Count;
            for (int i = 0; i < len; i++)
            {
                chk += list[i];
            }
        }
        watch.Stop();
        UnityEngine.Debug.Log(String.Format("List/for: {0}ms ({1})", watch.ElapsedMilliseconds, chk));
    
        chk = 0;
        watch = Stopwatch.StartNew();
        for (int rpt = 0; rpt < 100; rpt++)
        {
            int len = arr.Length;
            for (int i = 0; i < len; i++)
            {
                chk += arr[i];
            }
        }
        watch.Stop();
        UnityEngine.Debug.Log(String.Format("Array/for: {0}ms ({1})", watch.ElapsedMilliseconds, chk));
    
        chk = 0;
        watch = Stopwatch.StartNew();
        for (int rpt = 0; rpt < 100; rpt++)
        {
            foreach (int i in list)
            {
                chk += i;
            }
        }
        watch.Stop();
        UnityEngine.Debug.Log(String.Format("List/foreach: {0}ms ({1})", watch.ElapsedMilliseconds, chk));
    
        chk = 0;
        watch = Stopwatch.StartNew();
        for (int rpt = 0; rpt < 100; rpt++)
        {
            foreach (int i in arr)
            {
                chk += i;
            }
        }
        watch.Stop();
        UnityEngine.Debug.Log(String.Format("Array/foreach: {0}ms ({1})", watch.ElapsedMilliseconds, chk));
    }
