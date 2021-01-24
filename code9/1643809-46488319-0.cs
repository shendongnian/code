    void Awake()
    {
        UnityThread.initUnityThread();
    }
    
    void runQuery(string query)
    {
        ThreadPool.QueueUserWorkItem(RunInNewThread, query);
    }
    
    private void RunInNewThread(object a)
    {
        string query = (string)a;
        List<string> sqlResults = Database.query(query);
    
    
        //We are in another Thread. Use executeInUpdate to run in Unity main Thread
        UnityThread.executeInUpdate(() =>
        {
            updateMenu();
        });
    }
