    void Start()
    {
        StartCoroutine(timedCaller());
    }
    
    
    IEnumerator timedCaller()
    {
        WaitForSeconds waitTime = new WaitForSeconds(10);
        while (true)
        {
            //Call CloseAppList in another Thread
            ThreadPool.QueueUserWorkItem(new WaitCallback(CloseAppList));
            //Wait for 10 seconds
            yield return waitTime;
        }
    }
    
    void CloseAppList(object state)
    {
        Process[] processes = Process.GetProcesses();
        string pName = "";
        foreach (Process p in processes)
        {
            try
            {
                pName = p.ProcessName;
            }
            catch
            {
            }
        }
    }
