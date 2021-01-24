    //If M4.ALProj.BotMain needs to be recreated for each run then comment this line and uncomment the one in DoRunParallel()
    private static M4.ALProj.BotMain checkCharts = new M4.ALProj.BotMain();
    private static object SyncRoot = new object();
    private static System.Threading.Thread algoThread = null;
    private static bool ReRunOnComplete = false;
    public static void RunParallel()
    {
        lock (SyncRoot)
        {
            if (algoThread == null)
            {
                System.Threading.ThreadStart TS = new System.Threading.ThreadStart(DoRunParallel);
                algoThread = new System.Threading.Thread(TS);
            }
            else
            {
                //Recieved a recalc call while still calculating
                ReRunOnComplete = true;
            }
        }
    }
    public static void DoRunParallel()
    {
        bool ReRun = false;
        try
        {
            //If M4.ALProj.BotMain needs to be recreated for each run then uncomment this line and comment private static version above
            //M4.ALProj.BotMain checkCharts = new M4.ALProj.BotMain();
            checkCharts.RunAlgo();
        }
        finally
        {
            lock (SyncRoot)
            {
                algoThread = null;
                ReRun = ReRunOnComplete;
                ReRunOnComplete = false;
            }
        }
        if (ReRun)
        {
            RunParallel();
        }
    }
