    protected override void OnStart(string[] args)
        {
            LogService("Service started");
            NewThread = new Thread(runSysLog);
            NewThread.Start();
        }
        protected override void OnStop()
        {
            LogService("Service stopped");
            StopRequest.Set();
            //NewThread.Join();
        }
    public void runSysLog()
        {
            try
            {
                AutoResetEvent StopRequest = new AutoResetEvent(false);
                /* Main Loop */
                while (true)
                {
                    if (StopRequest.WaitOne(5000)) return;
                    try
                    { 
                        //while (udpListener.Available > 0)
                        if (udpListener.Available > 0)
                        {
                            //Some code here  
                        }
                    }
                    catch (Exception ex)
                    {
                        LogService("Whileloop exception: " +ex.ToString());
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                LogService("Run Sys Log Exception: " +ex.ToString());
                throw ex;
            }
        }
