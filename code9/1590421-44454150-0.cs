    ManualResetEvent mrse = new ManualResetEvent(false);    
     ThreadStart m_executeThreadStart;
            Thread m_executeThread;
            //user Selected Start Button
            private void Start()
            {
                m_executeThreadStart = new ThreadStart(method1);
                m_executeThread = new Thread(m_executeThreadStart);
                m_executeThread.Name = "ExecuteTestSession";
                m_executeThread.IsBackground = true;
                m_executeThread.Start();
    
                // Start the asynchronous operation.
                // InitializeBackgroundWorker();
                // backgroundWorker1.RunWorkerAsync();
    
                //Creating result sync thread
                ThreadStart m_resultSyncThreadStart = new ThreadStart(method2);
                Thread m_resultSyncThread = new Thread(m_resultSyncThreadStart);
                m_resultSyncThread.Name = "SyncResultDatabase";
                m_resultSyncThread.Start();
            }
            private void method1()
            {
                //do some work
                //read data from OPC sever (device)
                  mrse.WaitOne();
            }
            private void method2()
            {
                //do some work
                //updated database accordingly method 1 data
                  mrse.WaitOne();
            }
    
            //user Press Pause button
            public void Suspend()
            {
                //do work
                mrse.Reset();
                //do work
            }
    
            //user Press Resume button
            public void Resume()
            {
                //do work
                 mrse.Set();
                //do work
            }
