    public static class RunParallel
    {
        const int NumThreadsToRunInParallel = 8;// Tune this for your DB server performance characteristics
        public static void FillDataSet(ref DataSet Source)
        {
            WorkItemDefinition Work;
            foreach (DataRow r in Source.Tables["queries"].Rows)
            {
                Work = new WorkItemDefinition();
                Work.Query = r["QueryStatement"].ToString();
                Work.QSource = r["QuerySource"].ToString();
                Work.TableName = r["TableName"].ToString();
                EnQueueWork(Work);
            }
            System.Threading.ThreadStart NewThreadStart;
            NewThreadStart = new System.Threading.ThreadStart(ProcessPendingWork);
            for (int I = 0; I < NumThreadsToRunInParallel; I ++)
            {
                System.Threading.Thread NewThread;
                NewThread = new System.Threading.Thread(NewThreadStart);
                //NewThread.IsBackground = true; //Do this if you want to allow the application to quit before these threads finish all their work and exit
                ThreadCounterInc();
                NewThread.Start();
            }
            while (ThreadCounterValue > 0)
            {
                System.Threading.Thread.Sleep(1000);
            }
        }
        private static void ProcessPendingWork()
        {
            try
            {
                WorkItemDefinition Work;
                Work = DeQueueWork();
                while (Work != null)
                {
                    Work = DeQueueWork();
                    DbConnection db = new OdbcConnection();
                    // Set your connectionstring and execute the query and fill your data here
                }
            }
            finally
            {
                ThreadCounterDec();
            }
        }
        private static int ThreadCounter = 0;
        private static void ThreadCounterInc()
        {
            lock(SyncRoot)
            {
                ThreadCounter += 1;
            }
        }
        private static void ThreadCounterDec()
        {
            lock (SyncRoot)
            {
                ThreadCounter -= 1;
            }
        }
        private static int ThreadCounterValue
        {
            get
            {
                lock (SyncRoot)
                {
                    return ThreadCounter;
                }
            }
        }
        private static object SyncRoot = new object();
        private static Queue<WorkItemDefinition> m_PendingWork = new Queue<WorkItemDefinition>();
        private static Queue<WorkItemDefinition> PendingWork
        {
            get
            {
                return m_PendingWork;
            }
        }
        private static WorkItemDefinition DeQueueWork()
        {
            lock (SyncRoot)
            {
                if (PendingWork.Count > 0) // Catch exception overhead is higher
                {
                    return PendingWork.Dequeue();
                }
            }
            return null;
        }
        private static void EnQueueWork(WorkItemDefinition Work)
        {
            lock (SyncRoot)
            {
                PendingWork.Enqueue(Work);
            }
        }
        public class WorkItemDefinition
        {
            public string Query { get; set; }
            public string QSource { get; set; }
            public string TableName { get; set; }
        }
    }
